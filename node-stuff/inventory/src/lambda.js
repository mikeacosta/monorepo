import { ScanCommand, GetItemCommand } from "@aws-sdk/client-dynamodb";
import { marshall, unmarshall } from "@aws-sdk/util-dynamodb";
import { dbClient } from "./dbClient.js";

export const handler = async (event) => {
  console.log("request:", JSON.stringify(event, undefined, 2));

  try {
    let body = {};

    switch (event.httpMethod) {
      case "GET":
        if (event.pathParameters != null) {
          body = await getItem(event.pathParameters.sku);
        } else {
          body = await getAllItems();
        }
        break;

      case "POST":
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

const getItem = async (itemSku) => {
  console.log("getItem");
  try {
    const params = {
      TableName: process.env.TABLE_NAME,
      Key: marshall({ sku: itemSku })
    };

    const { Item } = await dbClient.send(new GetItemCommand(params));
    console.log(Item);
    return (Item) ? unmarshall(Item) : {};
  } catch (e) {
    console.error(e);
    throw e;
  }
}