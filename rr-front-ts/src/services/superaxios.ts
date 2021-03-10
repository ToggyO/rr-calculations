import axios from 'axios';
import type { AxiosRequestConfig } from 'axios';

const API_URL = 'http://185.227.108.172:5000/api';

const superaxios = axios.create({
  baseURL: API_URL,
});

superaxios.interceptors.request.use((config: AxiosRequestConfig) => {
  const headers = {
    Accept: 'application/json',
    'Content-Type': 'application/json',
    // 'Access-Control-Allow-Origin': '*',
  };
  return {
    ...config,
    headers,
  };
});

superaxios.interceptors.response.use(
  (response) => Promise.resolve(response),
  (error) => {
    const { response } = error;
    return Promise.reject(response);
  },
);

export default superaxios;
