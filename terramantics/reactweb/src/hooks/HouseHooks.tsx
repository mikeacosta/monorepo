import { House } from "./../types/house";
import { useQuery } from "react-query";
import Config from "../config";
import axios, { AxiosError } from "axios";

const useFetchHouses = () => {
  return useQuery<House[], AxiosError>("houses", () =>
    axios.get(`${Config.baseApiUrl}/houses`).then((resp) => resp.data)
  );
};

const useFetchHouse = (id: number) => {
  return useQuery<House, AxiosError>(["houses", id], () =>
    axios.get(`${Config.baseApiUrl}/houses/${id}`).then((resp) => resp.data)
  );
};

export {
  useFetchHouses,
  useFetchHouse,
};