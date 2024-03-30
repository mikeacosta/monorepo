import { SubscribeCommand } from "@aws-sdk/client-sns";
import { snsClient } from "./snsClient.js"

const params = {
  Token: "xxxxxxx",
  TopicArn: "arn:aws:sns:us-west-2:489967615225:sns-topic",
  AuthenticateOnUnsubscribe: "true"
};

export const run = async () => {
  try {
    const response = await snsClient.send(new SubscribeCommand(params));
    console.log("Success", response);
  } catch (err) {
    console.log("Error", err);
  }
};

run();