export const handler = async (event, context) => {
  console.log("request:", JSON.stringify(event, undefined, 2));

  return {
    statusCode: 200,
    "headers": { "content-type": "application/json" },
    body: JSON.stringify(event)
  };
}