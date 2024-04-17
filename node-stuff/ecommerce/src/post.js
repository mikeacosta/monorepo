import { PutItemCommand } from "@aws-sdk/client-dynamodb";
import { marshall } from "@aws-sdk/util-dynamodb";
import { v4 as uuidv4 } from 'uuid';
import { dbClient } from "./dbClient.js";

export const handler = async (event) => {
  try {
    console.log(`createProduct, event: "${event}"`);

    const productRequest = JSON.parse(event.body);
    const id = uuidv4();
    productRequest.id = id;

    const params = {
      TableName: process.env.TABLE_NAME,
      Item: marshall(productRequest || {})
    };
    
    let body = await dbClient.send(new PutItemCommand(params));

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
}