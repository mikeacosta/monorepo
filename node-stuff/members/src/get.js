import { GetItemCommand, ScanCommand } from "@aws-sdk/client-dynamodb";
import { marshall, unmarshall } from "@aws-sdk/util-dynamodb";
import { dbClient } from "./dbClient.js";

export const handler = async (event) => {
  console.log("request:", JSON.stringify(event, undefined, 2));

  try {
    let body = {};

    if (event.pathParameters != null) {
      body = await getMember(event.pathParameters.id);
    } else {
      body = await getMembers();
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

const getMember = async (memberId) => {
  console.log("getMember");
  try {
    const params = {
      TableName: process.env.TABLE_NAME,
      Key: marshall({ id: memberId })
    };

    const { Item } = await dbClient.send(new GetItemCommand(params));
    console.log(Item);
    return (Item) ? unmarshall(Item) : {};
  } catch (e) {
    console.error(e);
    throw e;
  }
}

const getMembers = async () => {
  console.log("getMembers");
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