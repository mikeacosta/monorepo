import { GetItemCommand, ScanCommand, PutItemCommand } from "@aws-sdk/client-dynamodb";
import { marshall, unmarshall } from "@aws-sdk/util-dynamodb";
import { v4 as uuidv4 } from 'uuid';
import { ddbClient } from "./ddbClient.js";

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

      case "POST":
        body = await createProduct(event);
        break;

      default:
        throw new Error(`Unsupported route: "${event.httpMethod}"`);
    }

    console.log(body);

    return {
      statusCode: 200,
      "headers": { "content-type": "application/json"},
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

const getProduct = async (productId) => {
  console.log("getProduct");
  try {

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

const createProduct = async (event) => {
  try {
    console.log(`createProduct, event: "${event}"`);
    
    const productRequest = JSON.parse(event.body);
    const id = uuidv4();
    productRequest.id = id;

    const params = {
      TableName: process.env.TABLE_NAME,
      Item: marshall(productRequest || {})
    };

    const createResult = await ddbClient.send(new PutItemCommand(params));
    console.log(createResult);
    return createResult;
  } catch (e) {
    console.error(e);
    throw e;
  }
}