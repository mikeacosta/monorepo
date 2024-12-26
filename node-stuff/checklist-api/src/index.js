import { ScanCommand, GetItemCommand, PutItemCommand, UpdateItemCommand, DeleteItemCommand } from "@aws-sdk/client-dynamodb";
import { unmarshall, marshall } from "@aws-sdk/util-dynamodb";
import { dbClient } from "./dbClient.js";

export const handler = async (event) => {
  console.log("request:", JSON.stringify(event, undefined, 2));

  try {
    let body = {};

    switch (event.httpMethod) {
      case "GET":
        if (event.pathParameters != null) {
          body = await getItem(event.pathParameters.id);
        } else {
          body = await getAllItems();
        }
        break;

      case "POST":
        body = await createItem(event);
        break;  
        
      case "PUT":
        body = await updateItem(event);
        break;        

      case "DELETE":
        body = await deleteItem(event);
        break;        

      default:
        throw new Error(`Unsupported route: "${event.httpMethod}"`);
    }  
    console.log(body);

    return {
      statusCode: 200,
      "headers": { 
        "content-type": "application/json",
        "Access-Control-Allow-Headers": "Content-Type",
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "GET, POST, OPTIONS, PUT, DELETE"        
      },
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

const getItem = async (itemId) => {
  console.log("getItem");
  try {
    const params = {
      TableName: process.env.TABLE_NAME,
      Key: marshall({ id: Number(itemId) })
    };

    const { Item } = await dbClient.send(new GetItemCommand(params));
    console.log(Item);
    return (Item) ? unmarshall(Item) : {};
  } catch (e) {
    console.error(e);
    throw e;
  }
}

const createItem = async (event) => {
  try {
    console.log(`createItem, event: "${event}"`);

    const itemRequest = JSON.parse(event.body);

    const params = {
      TableName: process.env.TABLE_NAME,
      Item: marshall(itemRequest || {})
    };

    const createResult = await dbClient.send(new PutItemCommand(params));
    console.log(createResult);
    return createResult;
  } catch (e) {
    console.error(e);
    throw e;
  }
}

const updateItem = async (event) => {
  try {
    const requestBody = JSON.parse(event.body);
    const objKeys = Object.keys(requestBody);
    console.log(`updateItem function. requestBody : "${requestBody}", objKeys: "${objKeys}"`);

    const params = {
      TableName: process.env.TABLE_NAME,
      Key: marshall({ id: Number(event.pathParameters.id) }),
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

const deleteItem = async (event) => {
  try {
    console.log("request:", JSON.stringify(event, undefined, 2));

    const params = {
      TableName: process.env.TABLE_NAME,
      Key: marshall({ id: Number(event.pathParameters.id) })
    };

    const deleteResult = await dbClient.send(new DeleteItemCommand(params));
    console.log(deleteResult);
    return deleteResult;
  } catch (e) {
    console.error(e);
    throw e;
  }
}