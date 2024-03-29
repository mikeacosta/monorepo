import { SNSClient } from "@aws-sdk/client-sns";

const REGION = "us-west-2";
const snsClient = new SNSClient({ region: REGION });

export { snsClient };