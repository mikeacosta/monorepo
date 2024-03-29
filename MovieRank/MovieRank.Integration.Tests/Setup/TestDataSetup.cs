using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace MovieRank.Integration.Tests.Setup;

public class TestDataSetup
{
    private static readonly IAmazonDynamoDB DynamoDbClient = new AmazonDynamoDBClient(new AmazonDynamoDBConfig() 
    {
        ServiceURL = "http://localhost:8000"
    });

    public async Task CreateTable()
    {
        var request = new CreateTableRequest
        {
            AttributeDefinitions = new List<AttributeDefinition>()
            {
                new AttributeDefinition
                {
                    AttributeName = "UserId",
                    AttributeType = "N"
                },
                new AttributeDefinition
                {
                    AttributeName = "MovieName",
                    AttributeType = "S"
                }
            },
            KeySchema = new List<KeySchemaElement>
            {
                new KeySchemaElement
                {
                    AttributeName = "UserId",
                    KeyType = "HASH"
                },
                new KeySchemaElement
                {
                    AttributeName = "MovieName",
                    KeyType = "RANGE"
                }
            },
            ProvisionedThroughput = new ProvisionedThroughput
            {
                ReadCapacityUnits = 1,
                WriteCapacityUnits = 1
            },
            TableName = "MovieRank",

            GlobalSecondaryIndexes = new List<GlobalSecondaryIndex>
            {
                new GlobalSecondaryIndex
                {
                    IndexName = "MovieName-index",
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "MovieName",
                            KeyType = "HASH"
                        }
                    },
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 1,
                        WriteCapacityUnits = 1
                    },
                    Projection = new Projection
                    {
                        ProjectionType = "ALL"
                    }
                }
            }
        };

        await DynamoDbClient.CreateTableAsync(request);
        await WaitUntilTableActive(request.TableName);
    }
    
    private static async Task WaitUntilTableActive(string tableName)
    {
        string? status = null;
        do
        {
            Thread.Sleep(3000);
            try
            {
                status = await GetTableStatus(tableName);
            }
            catch (ResourceNotFoundException)
            {
                // DescribeTable is eventually consistent
            }

        } while (status != "ACTIVE");
    }

    private static async Task<string> GetTableStatus(string tableName)
    {
        var response = await DynamoDbClient.DescribeTableAsync(new DescribeTableRequest
        {
            TableName = tableName
        });

        return response.Table.TableStatus;
    }    
}