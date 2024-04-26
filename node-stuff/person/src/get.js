import { GetItemCommand, ScanCommand } from "@aws-sdk/client-dynamodb";
import { marshall, unmarshall } from "@aws-sdk/util-dynamodb";
import { dbClient } from "./dbClient.js";

export const handler = async (event) => {
  try {
    console.log("request:", JSON.stringify(event));

    let body = {};

    if (event.pathParameters != null) {
      body = await getPerson(event.pathParameters.id);
    } else {
      body = await getPersons();
    }

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

const getPerson = async (personId) => {
  console.log("getPerson");

  try {
    const params = {
      TableName: process.env.TABLE_NAME,
      Key: marshall({ id: personId })
    };

    const { Item } = await dbClient.send(new GetItemCommand(params));
    console.log("response:", Item);
    let body = (Item) ? unmarshall(Item) : {};

    return {
      statusCode: 200,
      "headers": { "content-type": "application/json" },
      body: JSON.stringify(body)
    }; 

  } catch (e) {
    console.error(e);
    throw e;
  }
}

const getPersons = async () => {
  console.log("getPersons");

  try {
    const params = {
      TableName: process.env.TABLE_NAME
    };

    const { Items } = await dbClient.send(new ScanCommand(params));
    console.log("response:", Items);
    return (Items) ? Items.map((item) => unmarshall(item)) : {};

  } catch (e) {
    console.error(e);
    throw e;
  }
}