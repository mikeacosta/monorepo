import { UnsubscribeCommand } from "@aws-sdk/client-sns";
import { snsClient } from "./snsClient.js"

const params = {
  SubscriptionArn: "arn:aws:sns:us-west-2:489967615225:sns-topic:7e094713-83e4-40ba-a3c9-1b28a94792c2",
  Protocol: "email",
  TopicArn: "arn:aws:sns:us-west-2:489967615225:sns-topic",
  Endpoint: "user@postcore.net"
}

export const run = async () => {
  try {
    const command = new UnsubscribeCommand(params);
    const response = await snsClient.send(command);
    console.log("Success", response);
  } catch (err) {
    console.log("Error", err);
  }
};

run();