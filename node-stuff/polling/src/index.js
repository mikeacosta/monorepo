exports.handler = async (event, context) => {
  console.log("***event***", JSON.stringify(event, undefined, 2));

  event.Records.forEach(record => {
    const { body } = record;
    console.log(body);
  });

  return {
    statusCode: 200,
    "headers": { "content-type": "application/json" },
    body: JSON.stringify(event)
  };
}