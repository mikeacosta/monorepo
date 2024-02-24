export const handler = async (event) => {
  console.log("request:", JSON.stringify(event, undefined, 2));

  // TODO: implement

  const response = {
    statusCode: 200,
    headers: {"Content-Type": "text/plain"},
    body: JSON.stringify("hey man!")
  };
  return response;
};