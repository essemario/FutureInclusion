import axios from 'axios';

const api = axios.create({
    baseURL: 'https://futureinclusionbackend.azurewebsites.net/api/'
});

export default api;