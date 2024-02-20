using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;

namespace Customers.Consumer;

public class QueueConsumerService : BackgroundService
{
    private readonly IAmazonSQS _sqs;
    private readonly IOptions<QueueSettings> _queueSettings;

    public QueueConsumerService(IAmazonSQS sqs, IOptions<QueueSettings> queueSettings)
    {
        _sqs = sqs;
        _queueSettings = queueSettings;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var queueUrlResponse = await _sqs.GetQueueUrlAsync("customers", stoppingToken);

        var receiveMessageRequest = new ReceiveMessageRequest
        {
            QueueUrl = queueUrlResponse.QueueUrl,
            AttributeNames = new List<string> { "All "},
            MessageAttributeNames = new List<string> { "All "},
            MaxNumberOfMessages = 1
        };

        while (!stoppingToken.IsCancellationRequested)
        {
            var response = await _sqs.ReceiveMessageAsync(receiveMessageRequest, stoppingToken);
            foreach (var msg in response.Messages)
            {
                var msgType = msg.MessageAttributes["MessageType"];
                // process message
                
                await _sqs.DeleteMessageAsync(queueUrlResponse.QueueUrl, msg.ReceiptHandle, stoppingToken);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}