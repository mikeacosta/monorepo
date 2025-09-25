import { DynamoDBClient, PutItemCommand } from "@aws-sdk/client-dynamodb";
import { marshall } from "@aws-sdk/util-dynamodb";
import { v4 as uuidv4 } from 'uuid';

const TODO_TABLE = process.env.TODO_TABLE;
const REGION = "us-west-2";
const dbClient = new DynamoDBClient({ region: REGION });

export const createToDo = async (event) => {
  console.log("event:", JSON.stringify(event, undefined, 2));

  const data = JSON.parse(event.body);  // deserialize the JSON body
  const timestamp = new Date().getTime();
  data.id = uuidv4();
  data.checked = false;
  data.createdAt = timestamp;
  data.updatedAt = timestamp;

  if (typeof data.todo !== "string") {
    console.error("Validation Failed");
    return {
      statusCode: 400,
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ message: 'Invalid input: "todo" must be a string' })
    };
  }
  let body;
  let statusCode = 200;
  const headers = {
    "Content-Type": "application/json",
  };

  const params = {
    TableName: TODO_TABLE,
    Item: marshall(data || {})
  };

  if (typeof data.todo !== "string") {
    console.error("Validation Failed");
    return;
  }

  try {
    body = await dbClient.send(new PutItemCommand(params));
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