import { GetItemCommand, ScanCommand, PutItemCommand } from "@aws-sdk/client-dynamodb";
import { marshall, unmarshall } from "@aws-sdk/util-dynamodb";
import { v4 as uuidv4 } from 'uuid';
import { ddbClient } from "./ddbClient.js";

export const handler = async (event) => {
  console.log("request:", JSON.stringify(event, undefined, 2));

  try {
    let body = {};

    if (event.httpMethod === "POST") {
      body = createPerson(event);
    }

    return {
      statusCode: 200,
      "headers": { "content-type": "application/json" },
      body: JSON.stringify(body)
    };    
  } catch (e) {
    console.error(e);

    return {
      statusCode: 500,
      body: JSON.stringify({
        message: "Error occurred",
        errorMsg: e.message,
        errorStack: e.errorStack
      })
    };
  }
};

const createPerson = async (event) => {
  try {
    console.log(`createPerson, event: "${event}"`);

    const personRequest = JSON.parse(event.body);
    const id = uuidv4();
    personRequest.id = id;

    const params = {
      TableName: process.env.TABLE_NAME,
      Item: marshall(personRequest || {})
    };

    const createResult = await ddbClient.send(new PutItemCommand(params));
    console.log(createResult);
    return createResult;
  } catch (e) {
    throw e;
  }
}