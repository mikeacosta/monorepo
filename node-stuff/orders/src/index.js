import { dbClient } from "./dbClient.js";
import { DynamoDBClient, DescribeTableCommand } from "@aws-sdk/client-dynamodb";

export const run = async () => {
  try {
    const input = { // DescribeTableInput
      TableName: "Orders", // required
    };
    const command = new DescribeTableCommand(input);
    const response = await dbClient.send(command);

    console.log('response', response);

  } catch (error) {
    console.log('error', error);
  }
}

run();