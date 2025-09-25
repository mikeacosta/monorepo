import { DynamoDBClient, ScanCommand } from "@aws-sdk/client-dynamodb";
import { unmarshall } from "@aws-sdk/util-dynamodb";

const TODO_TABLE = process.env.TODO_TABLE;
const REGION = "us-west-2";
const dbClient = new DynamoDBClient({ region: REGION });

export const listTodos = async (event) => {
  console.log("event:", JSON.stringify(event, undefined, 2));

  let body;
  let statusCode = 200;
  const headers = {
    "Content-Type": "application/json",
  };

  const params = {
    TableName: TODO_TABLE
  };

  try {
    const data = await dbClient.send(new ScanCommand(params));
    body = data.Items.map(item => unmarshall(item));
  } catch (err) {
    statusCode = 400;
    body = err.message;
    console.log(err);
  } finally {
    console.log("response body:", JSON.stringify(body, undefined, 2));
    body = JSON.stringify(body);
  }

  return {
    statusCode,
    body,
    headers
  };
}