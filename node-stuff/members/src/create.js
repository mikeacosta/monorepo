import { PutItemCommand } from "@aws-sdk/client-dynamodb";
import { marshall } from "@aws-sdk/util-dynamodb";
import { v4 as uuidv4 } from 'uuid';
import { dbClient } from "./dbClient.js";

export const handler = async (event) => {
  try {
    console.log(`createMember, event: "${event}"`);

    const memberRequest = JSON.parse(event.body);
    const id = uuidv4();
    memberRequest.id = id;

    const params = {
      TableName: process.env.TABLE_NAME,
      Item: marshall(memberRequest || {})
    };

    let body = await dbClient.send(new PutItemCommand(params));

    return {
      statusCode: 200,
      "headers": { "content-type": "application/json" },
      body: JSON.stringify(body)
    };       

  } catch (e) {
    console.log(e);

    return {
      statusCode: 500,
      body: JSON.stringify({
        message: "Error occurred",
        errorMsg: e.message,
        errorStack: e.errorStack
      })
    };      
  }
}