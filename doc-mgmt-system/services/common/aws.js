import * as AWS from 'aws-sdk';

let _dynamoDB;

const dynamoDB = () => {
  if (!_dynamoDB) {
    _dynamoDB = new AWS.DynamoDB.DocumentClient();
  }
  return _dynamoDB;  
}

export const AWSClients = {
  dynamoDB,
};