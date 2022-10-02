<template>
  <v-app>
    <v-layout full-height>
      <Navigation v-if="isLogin" />
      <v-main>
        <router-view />
      </v-main>
    </v-layout>
  </v-app>
</template>

<script lang="ts" setup>
import { computed } from "vue";
import Navigation from "./components/Navigation.vue";
import { useLoginUserInfoStore } from "./store/LoginUserInfo";
import { storeToRefs } from "pinia";

const loginUserInfoStore = useLoginUserInfoStore();
const { loginUserInfo } = storeToRefs(loginUserInfoStore);
const isLogin = computed(() => {
  return loginUserInfo.value?.isLogin;
});
</script>
