import { DynamoDBClient } from "@aws-sdk/client-dynamodb";

const REGION = "us-west-2";
const dbClient = new DynamoDBClient({ region: REGION });

export { dbClient };