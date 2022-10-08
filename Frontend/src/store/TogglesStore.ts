import { defineStore } from "pinia";
import { ref } from "vue";

export const useTogglesStore = defineStore("togglesStore", () => {
  const isOpenChatRoom = ref<boolean>(false);
  function setIsOpenChatRoom(data: boolean) {
    isOpenChatRoom.value = data;
  }

  return { isOpenChatRoom, setIsOpenChatRoom };
});
