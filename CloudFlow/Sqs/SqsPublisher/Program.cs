﻿using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using SqsPublisher;

var sqsClient = new AmazonSQSClient();

var customer = new CustomerCreated()
{
    Id = Guid.NewGuid(),
    Email = "joeblow@gmail.com",
    FullName = "Joe Blow",
    DateOfBirth = new DateTime(1980, 1, 15),
    GitHubUsername = "joeblow"
};

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");

var sendMessageRequest = new SendMessageRequest()
{
    QueueUrl = queueUrlResponse.QueueUrl,
    MessageBody = JsonSerializer.Serialize(customer),
    MessageAttributes = new Dictionary<string, MessageAttributeValue>()
    {
        {
            "MessageType", new MessageAttributeValue() { DataType = "String", StringValue = nameof(CustomerCreated) }
        }
    }
};

var response = await sqsClient.SendMessageAsync(sendMessageRequest);

Console.WriteLine(response.ToString());