import axios from "axios";

export default {
  GetChatInfos(userId: string) {
    return axios.get(`${process.env.VUE_APP_API_URL}/chat/GetChatInfos`, {
      params: { userId: userId },
    });
  },
  GrtRecentChatList(userId: string) {
    return axios.get(
      `${process.env.VUE_APP_API_URL}/chat/GetRecentChatListInfos`,
      {
        params: { userId: userId },
      }
    );
  },
};
