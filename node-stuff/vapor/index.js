const moment = require('moment');
const greeting = {
  "en": "hello",
  "fr": "bonjour",
  "es": "hola",
  "it": "ciao",
  "de": "hallo"
}

exports.handler = async (event) => {
  let name = event.pathParameters.name;
  let { lang, ...info } = event.queryStringParameters || {};

  let message = `${greeting[lang] ? greeting[lang] : greeting['en']} ${name}`;
  let response = {
    message: message,
    info: info,
    timestamp: moment().unix()
  }

  return {
    statusCode: 200,
    body: JSON.stringify(response)
  }  
}