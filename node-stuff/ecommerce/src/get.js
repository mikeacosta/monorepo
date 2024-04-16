import { GetItemCommand } from "@aws-sdk/client-dynamodb";
import { marshall, unmarshall } from "@aws-sdk/util-dynamodb";
import { dbClient } from "./dbClient.js";

export const handler = async (event) => {
  console.log("request:", JSON.stringify(event, undefined, 2));

  try {
    console.log("getProduct");

    const params = {
      TableName: process.env.TABLE_NAME,
      Key: marshall({ id: event.pathParameters.id })
    };

    const { Item } = await dbClient.send(new GetItemCommand(params));
    console.log(Item);
    let body = (Item) ? unmarshall(Item) : {};

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