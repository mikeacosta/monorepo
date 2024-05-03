import { v4 as uuidv4 } from 'uuid';
import xmlConverter from "xml-js";

export const handler = async (event) => {
  // TODO implement
  console.log("request:", JSON.stringify(event, undefined, 2));
  console.log("request body:", event.body);

  var now = new Date().toISOString();
  var id = uuidv4();

  var json = xmlConverter.xml2json(event.body, { compact: true, spaces: 2 })
    .replace("#date#", now)
    .replace("#uuid#", id);

  console.log("converted:", json);

  const response = {
    statusCode: 200,
    body: json,
  };
  return response;
};