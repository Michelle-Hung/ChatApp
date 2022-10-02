import { LoginUserInfo } from "@/models/LoginUserInfo";
import { defineStore } from "pinia";
import { ref } from "vue";

export const useLoginUserInfoStore = defineStore("loginUserInfo", () => {
  const loginUserInfo = ref<LoginUserInfo>({
    id: "0",
    name: "anonymous",
    isLogin: false,
  });
  function setLoginUserInfo(data: LoginUserInfo) {
    loginUserInfo.value = data;
  }

  return { loginUserInfo, setLoginUserInfo };
});
