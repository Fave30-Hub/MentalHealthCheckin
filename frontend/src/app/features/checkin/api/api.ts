import axios from 'axios';

const API_BASE = 'https://localhost:7003/api';

const api = axios.create({
  baseURL: API_BASE,
});

api.interceptors.request.use((config) => {
  const token = localStorage.getItem('LICENSE_TOKEN');
  if (token && config.headers) {
    config.headers['X-License-Token'] = token;
  }
  return config;
});

export default api;