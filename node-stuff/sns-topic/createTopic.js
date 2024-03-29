import { CreateTopicCommand } from "@aws-sdk/client-sns";
import { snsClient } from "./snsClient.js";

const params = {
  Name: "sns-topic"
};

export const run = async () => {
  try {
    const command = new CreateTopicCommand(params);
    const response = await snsClient.send(command);
    console.log("Success", response);
  } catch(err) {
    console.log("Error", err);
  }
};

run();