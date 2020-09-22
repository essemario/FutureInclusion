import axios from 'axios';
const api = axios.create({
  baseURL: 'https://futureinclusionbackend.azurewebsites.net/api/'
});

const loadFeed = async (callback) => {
  const response = await api.get("Postagens");
  callback(response.data);
};

export default loadFeed;

//export default api;