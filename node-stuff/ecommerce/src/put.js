import { UpdateItemCommand } from "@aws-sdk/client-dynamodb";
import { marshall } from "@aws-sdk/util-dynamodb";
import { dbClient } from "./dbClient.js";

export const handler = async (event) => {
  try {
    console.log("request:", JSON.stringify(event, undefined, 2));

    let body = await updateProduct(event);

    console.log(body);

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

const updateProduct = async (event) => {
  try {
    const requestBody = JSON.parse(event.body);
    const objKeys = Object.keys(requestBody);
    console.log(`updateProduct function. requestBody : "${requestBody}", objKeys: "${objKeys}"`);

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