import { ScanCommand } from "@aws-sdk/client-dynamodb";
import { unmarshall } from "@aws-sdk/util-dynamodb";
import { dbClient } from "./dbClient.js";

export const handler = async (event) => {
  console.log("request:", JSON.stringify(event, undefined, 2));

  try {
    let body = {};

    switch (event.httpMethod) {
      case "GET":
        if (event.pathParameters != null) {
          //body = await getItem(event.pathParameters.sku);
        } else {
          body = await getAllItems();
        }
        break;

      default:
        throw new Error(`Unsupported route: "${event.httpMethod}"`);
    }  
    console.log(body);

    return {
      statusCode: 200,
      "headers": { "content-type": "application/json" },
      body: JSON.stringify(body)
    };    
    
  } catch (e) {
    console.error(e);
  }
};

const getAllItems = async () => {
  console.log("getAllItems");
  try {
    const params = {
      TableName: process.env.TABLE_NAME
    };

    const { Items } = await dbClient.send(new ScanCommand(params));
    console.log(Items);
    return (Items) ? Items.map((item) => unmarshall(item)) : {};

  } catch (e) {
    console.error(e);
    throw e;
  }
}