import { PutItemCommand, UpdateItemCommand } from "@aws-sdk/client-dynamodb";
import { marshall } from "@aws-sdk/util-dynamodb";
import { v4 as uuidv4 } from 'uuid';
import { dbClient } from "./dbClient.js";

export const handler = async (event) => {
  console.log("request:", JSON.stringify(event, undefined, 2));

  try {
    let body = {};
    console.log("event.httpMethod", event.httpMethod);

    if (event.httpMethod === "POST") {
      body = await createPerson(event);
    }

    if (event.httpMethod === "PUT") {
      body = await updatePerson(event);
    }    

    console.log("response body: ", JSON.stringify(body));

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
    const personRequest = JSON.parse(event.body);
    const id = uuidv4();
    personRequest.id = id;

    console.log(`personRequest: "${JSON.stringify(personRequest)}"`);

    const params = {
      TableName: process.env.TABLE_NAME,
      Item: marshall(personRequest || {})
    };

    const createResult = await dbClient.send(new PutItemCommand(params));
    return createResult;
  } catch (e) {
    console.error(e);
    throw e;
  }
}

const updatePerson = async (event) => {
  try {
    const requestBody = JSON.parse(event.body);
    const objKeys = Object.keys(requestBody);
    console.log(`updatePerson function. requestBody : "${requestBody}", objKeys: "${objKeys}"`);

    const params = {
      TableName: process.env.TABLE_NAME,
      Key: marshall({ id: event.pathParameters.id }),
      UpdateExpression: `SET ${objKeys.map((_, index) => `#key${index} = :value${index}`).join(", ")}`,
      ExpressionAttributeNames: objKeys.reduce((acc, key, index) => ({
        ...acc,
        [`#key${index}`]: key,
      }), {}),
      ExpressionAttributeValues: marshall(objKeys.reduce((acc, key, index) => ({
        ...acc,
        [`:value${index}`]: requestBody[key],
      }), {})),
    };

    const updateResult = await dbClient.send(new UpdateItemCommand(params));
    return updateResult;
  } catch (e) {
    console.error(e);
    throw e;
  }
}