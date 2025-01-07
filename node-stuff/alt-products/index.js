import { GetItemCommand, ScanCommand } from "@aws-sdk/client-dynamodb";
import { marshall, unmarshall } from "@aws-sdk/util-dynamodb";
import { dbClient } from "./dbClient.js";

export const handler = async (event) => {
  console.log("request:", JSON.stringify(event, undefined, 2));

  try {
    let body = {};

    switch (event.httpMethod) {
      case "GET":
        if (event.pathParameters != null) {
          body = await getProduct(event.pathParameters.id);
        } else {
          body = await getProducts();
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

const getProduct = async (id) => {
  console.log("getProduct");
  try {
    const params = {
      TableName: process.env.TABLE_NAME,
      Key: marshall({ id: Number(id) })
    };

    const { Item } = await dbClient.send(new GetItemCommand(params));
    console.log(Item);
    return (Item) ? unmarshall(Item) : {};
  } catch (e) {
    console.error(e);
    throw e;
  }
}

const getProducts = async () => {
  console.log("getProducts");
  try {
    const params = {
      TableName: process.env.TABLE_NAME
    };

    const { Items } = await ddbClient.send(new ScanCommand(params));
    console.log(Items);
    return (Items) ? Items.map((item) => unmarshall(item)) : {};

  } catch (e) {
    console.error(e);
    throw e;
  }
}