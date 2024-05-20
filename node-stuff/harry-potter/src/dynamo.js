import { ScanCommand, GetItemCommand, PutItemCommand, DeleteItemCommand } from "@aws-sdk/client-dynamodb";
import { marshall, unmarshall } from "@aws-sdk/util-dynamodb";
import { dbClient } from "./dbClient.js";

const TABLE_NAME = "HarryPotter";

export const getCharacters = async () => {
  const params = {
    TableName: TABLE_NAME
  };

  const { Items } = await dbClient.send(new ScanCommand(params));
  console.log(Items);
  return (Items) ? Items.map((item) => unmarshall(item)) : {};  
};

export const getCharacterById = async (id) => {
  const params = {
    TableName: TABLE_NAME,
    Key: marshall({ id: id })
  };

  const { Item } = await dbClient.send(new GetItemCommand(params));
  console.log(Item);
  return (Item) ? unmarshall(Item) : {};
};

export const addOrUpdateCharacter = async (character) => {
  const params = {
    TableName: TABLE_NAME,
    Item: marshall(character)
  };  

  const result = await dbClient.send(new PutItemCommand(params));
  console.log(result);
  return result;
};

export const deleteCharacter = async (id) => {
  const params = {
    TableName: TABLE_NAME,
    Key: marshall({ id: id })
  };

  const deleteResult = await dbClient.send(new DeleteItemCommand(params));  
  return deleteResult
};

//getCharacters();
//getCharacterById("0");
//deleteCharacter("0");

const hp = {
  "id": "0",
  "name": "Harry Potter",
  "alternate_names": [
    "The Boy Who Lived",
    "The Chosen One",
    "Undesirable No. 1",
    "Potty"
  ],
  "species": "human",
  "gender": "male",
  "house": "Gryffindor",
  "dateOfBirth": "31-07-1980",
  "yearOfBirth": 1980,
  "wizard": true,
  "ancestry": "half-blood",
  "eyeColour": "green",
  "hairColour": "black",
  "wand": {
    "wood": "holly",
    "core": "phoenix tail feather",
    "length": 11
  },
  "patronus": "stag",
  "hogwartsStudent": true,
  "hogwartsStaff": false,
  "actor": "Daniel Radcliffe",
  "alternate_actors": [],
  "alive": true,
  "image": "https://ik.imagekit.io/hpapi/harry.jpg"
};

//addOrUpdateCharacter(hp);