export const handler = async (event) => {
  // TODO implement
  console.log("request:", JSON.stringify(event, undefined, 2));

  console.log(event.body);

  const response = {
    statusCode: 200,
    body: JSON.stringify('Hey!'),
  };
  return response;
};
