import { ScanCommand } from "@aws-sdk/client-dynamodb";
import { unmarshall } from "@aws-sdk/util-dynamodb";
import { ddbClient } from "./ddbClient.js";

export const handler = async (event) => {
  console.log("request:", JSON.stringify(event, undefined, 2));

  try {
    let body = await getProducts();

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