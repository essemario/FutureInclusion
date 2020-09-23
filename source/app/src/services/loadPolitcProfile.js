import axios from 'axios';
const api = axios.create({
  baseURL: 'https://futureinclusionbackend.azurewebsites.net/api/'
});
const loadPolitcProfile = async (callback, id) => {
  const response = await api.get(`PerfilPolitico/${id}`);
  callback(response.data);
};
export default loadPolitcProfile;