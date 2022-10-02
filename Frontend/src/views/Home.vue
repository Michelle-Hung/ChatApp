<template>
  <Login v-if="!isLogin" />
  <Chat v-else-if="isLogin" />
</template>

<script lang="ts" setup>
import { computed } from "vue";
import Chat from "../components/Chat.vue";
import Login from "../components/Login.vue";
import { useLoginUserInfoStore } from "@/store/LoginUserInfo";
import { storeToRefs } from "pinia";

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
</script>
