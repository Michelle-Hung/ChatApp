<template>
  <h1>Hi {{ myNickName }}, Welcome to chat App</h1>
</template>
<script lang="ts" setup>
import { useLoginUserInfoStore } from "@/store/LoginUserInfo";
const loginUserInfoStore = useLoginUserInfoStore();
const myNickName = loginUserInfoStore.$state.loginUserInfo.name;
</script>
