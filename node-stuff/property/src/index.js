import fetch from "node-fetch";
import { v4 as uuidv4 } from 'uuid';

const url1 = 'http://demo2540837.mockable.io/property/simple';
const url2 = 'http://demo2540837.mockable.io/property/full';

const getData = (url) => {
  return new Promise((resolve, reject) => {
    fetch(url)
      .then((response) => response.text())
      .then((data) => {
        // console.log(data)
        resolve(data)
      })
  })
}

const getResult = (data) => {
  const id = uuidv4();
  const date = new Date();
  return data.replace('#uuid#', id).replace('#date#', date.toISOString());
}

const run = async () => {
  let dataRequest = null;

  for (let i = 0; i < 5; i++) {
    dataRequest = (getData(url1));

    await dataRequest.then((data) => {
      const id = uuidv4();
      let result = getResult(data);
      console.log(result);
    });
  }

}

await run();