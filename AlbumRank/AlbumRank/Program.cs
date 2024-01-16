using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddDefaultAWSOptions(new AWSOptions()
{
    Region = RegionEndpoint.GetBySystemName("us-west-2")
});

var app = builder.Build();

app.MapControllers();

app.Run();