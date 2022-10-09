<template>
  <Login v-if="!isLogin" />
  <WelcomeToChatApp v-else-if="isLogin && !isOpenChatRoom" />
  <Chat v-else-if="isLogin && isOpenChatRoom" />
</template>

<script lang="ts" setup>
import { computed } from "vue";
import Login from "../components/Login.vue";
import { useLoginUserInfoStore } from "@/store/LoginUserInfo";
import { useTogglesStore } from "@/store/TogglesStore";
import { storeToRefs } from "pinia";
import Chat from "@/components/Chat.vue";
import WelcomeToChatApp from "./WelcomeToChatApp.vue";

// @Options({
//   components: {
//     HelloWorld,
//     Chat,
//     Login,
//   },
// })
// export default class Home extends Vue {
//   setup() {

//     const isLogin = computed(() => {
//       return store.getters.isLogin});
//     return { isLogin }
//   }
// }
const loginUserInfoStore = useLoginUserInfoStore();
const { loginUserInfo } = storeToRefs(loginUserInfoStore);
const isLogin = computed(() => {
  return loginUserInfo.value?.isLogin;
});

const togglesStore = useTogglesStore();
const isOpenChatRoom = computed(() => {
  return togglesStore.$state.isOpenChatRoom;
});
</script>
