import axios from 'axios';
const api = axios.create({
  baseURL: 'https://futureinclusionbackend.azurewebsites.net/api/'
});
const loadPersonalProfile = async (callback, id) => {
  const response = await api.get(`PerfilPessoal/${id}`);
  callback(response.data);
};
export default loadPersonalProfile;