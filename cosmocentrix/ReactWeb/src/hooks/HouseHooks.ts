import type { House } from "../types/house";
import config from "../config";
import { useQuery } from "@tanstack/react-query";
import type { AxiosError } from "axios";
import axios from "axios";

const useFetchHouses = () => {
  return useQuery<House[], AxiosError>({
    queryKey: ["houses"],
    queryFn: () =>
      axios.get(`${config.baseApiUrl}/houses`).then((response) => response.data),
  });
};

export default useFetchHouses;