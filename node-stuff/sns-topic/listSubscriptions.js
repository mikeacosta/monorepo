import { ListSubscriptionsByTopicCommand } from "@aws-sdk/client-sns"; 
import { snsClient } from "./snsClient.js"

const params = {
  TopicArn: "arn:aws:sns:us-west-2:489967615225:sns-topic"
};

export const run = async () => {
  try {
      const command = new ListSubscriptionsByTopicCommand(params);
      const response = await snsClient.send(command);
      console.log("Success", response);
  } catch (err) {
    console.log("Error", err);
  }
};

run();