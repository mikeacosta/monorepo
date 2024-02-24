import { DynamoDBClient } from "@aws-sdk/client-dynamodb";

const REGION = "us-west-2";
const ddbClient = new DynamoDBClient({ region: REGION });

export { ddbClient };