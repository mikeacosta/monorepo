import axios from 'axios';
import { addOrUpdateCharacter } from "./dynamo.js";

const seedData = async () => {
  const url = "https://hp-api.onrender.com/api/characters";

  try {
    const {data : characters} = await axios.get(url);

    const promises = characters.map((character, i) => 
      addOrUpdateCharacter({...character, id: i + ''})
    );
    await Promise.all(promises);
  } catch (e) {
      console.error("ERROR: ", e);
  }
};

seedData();