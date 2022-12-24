import { ChatRoomInfo } from "@/models/ChatRoomInfo";
import { defineStore } from "pinia";
import { ref } from "vue";

export const useChatRoomInfoStore = defineStore("chatRoomInfo", () => {
  const chatRoomInfo = ref<ChatRoomInfo>({
    channelId: "0",
    channelName: "default",
    channelType: "undefine",
    sendTo: {
      userId: "1",
      displayName: "default",
    },
  });
  function setchatRoomInfo(data: ChatRoomInfo) {
    chatRoomInfo.value = data;
  }

  return { chatRoomInfo, setchatRoomInfo };
});
