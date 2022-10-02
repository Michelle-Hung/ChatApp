import axios from "axios";

export default {
  GetContacts(userId: string) {
    return axios.get(`${process.env.VUE_APP_API_URL}/chat/GetContacts`, {
      params: { userId: userId },
    });
  },
};
