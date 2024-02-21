using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using Customers.Consumer.Messages;
using MediatR;
using Microsoft.Extensions.Options;

namespace Customers.Consumer;

public class QueueConsumerService : BackgroundService
{
    private readonly IAmazonSQS _sqs;
    private readonly IOptions<QueueSettings> _queueSettings;
    private readonly IMediator _mediator;
    private readonly ILogger<QueueConsumerService> _logger;

    public QueueConsumerService(IAmazonSQS sqs, 
        IOptions<QueueSettings> queueSettings,
        IMediator mediator,
        ILogger<QueueConsumerService> logger)
    {
        _sqs = sqs;
        _queueSettings = queueSettings;
        _mediator = mediator;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var queueUrlResponse = await _sqs.GetQueueUrlAsync(_queueSettings.Value.Name, stoppingToken);

        var receiveMessageRequest = new ReceiveMessageRequest
        {
            QueueUrl = queueUrlResponse.QueueUrl,
            AttributeNames = new List<string> {"All"},
            MessageAttributeNames = new List<string> {"All"},
            MaxNumberOfMessages = 1
        };

        while (!stoppingToken.IsCancellationRequested)
        {
            var response = await _sqs.ReceiveMessageAsync(receiveMessageRequest, stoppingToken);
            foreach (var msg in response.Messages)
            {
                var msgType = msg.MessageAttributes["MessageType"];
                var type = Type.GetType($"Customers.Consumer.Messages.{msgType.StringValue}");
                if (type is null)
                {
                    _logger.LogWarning("Unknown message type: {}", msgType);
                    continue;
                }

                var typedMessage = (ISqsMessage)JsonSerializer.Deserialize(msg.Body, type)!;

                try
                {
                    await _mediator.Send(typedMessage, stoppingToken);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Message failed during processing");
                    continue;
                }
                
                await _sqs.DeleteMessageAsync(queueUrlResponse.QueueUrl, msg.ReceiptHandle, stoppingToken);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}