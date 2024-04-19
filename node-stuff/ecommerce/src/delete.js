import { DeleteItemCommand } from "@aws-sdk/client-dynamodb";
import { marshall } from "@aws-sdk/util-dynamodb";
import { dbClient } from "./dbClient.js";

export const handler = async (event) => {
  console.log("request:", JSON.stringify(event, undefined, 2));
  
  try {
    console.log("deleteProduct");
    
    const params = {
      TableName: process.env.TABLE_NAME,
      Key: marshall({ id: event.pathParameters.id })
    };    

    const deleteResult = await dbClient.send(new DeleteItemCommand(params));

    return {
      statusCode: 204,
      "headers": { "content-type": "application/json" },
      body: JSON.stringify(deleteResult)
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