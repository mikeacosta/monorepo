using System.Text.Json;
using System.Text.Json.Nodes;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using SnsPublisher;

var snsClient = new AmazonSimpleNotificationServiceClient();

var customer = new CustomerCreated()
{
    Id = Guid.NewGuid(),
    Email = "jjackson@gmail.com",
    FullName = "Jennifer Jackson",
    DateOfBirth = new DateTime(1980, 1, 15),
    GitHubUsername = "jjcoder"
};

var topicArnResponse = await snsClient.FindTopicAsync("customers");

var publishRequest = new PublishRequest
{
    TopicArn = topicArnResponse.TopicArn,
    Message = JsonSerializer.Serialize(customer),
    MessageAttributes = new Dictionary<string, MessageAttributeValue>()
    {
        {
            "MessageType", new MessageAttributeValue() { DataType = "String", StringValue = nameof(CustomerCreated) }
        }
    }
};

var response = await snsClient.PublishAsync(publishRequest);

Console.WriteLine(response.ToString());