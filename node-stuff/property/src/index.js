import fetch from "node-fetch";

const getData = (url) => {
  return new Promise((resolve, reject) => {
    fetch(url)
      .then((response) => response.text())
      .then((data) => {
        console.log(data)
        resolve(data)
      })
  })
}

getData('http://demo2540837.mockable.io/property/simple');