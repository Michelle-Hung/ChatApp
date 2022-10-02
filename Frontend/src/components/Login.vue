<template>
  <v-container sm="12" xs="6" fluid>
    <v-alert
      v-if="isShowLoginErrorMessage"
      type="error"
      prominent
      variant="outlined"
    >
      Login Fail</v-alert
    >
    <v-card class="mx-auto" height="100%" max-width="80%" min-width="50%">
      <v-card-header>
        <v-card-header-text>
          <v-card-title class="justify-center"> Welcom </v-card-title>
        </v-card-header-text>
      </v-card-header>
      <v-card-text>
        <v-form>
          <v-text-field v-model="userName" label="Name" required></v-text-field>
          <v-text-field
            v-model="password"
            :append-inner-icon="
              showPassword ? 'mdi:mdi-eye' : 'mdi:mdi-eye-off'
            "
            label="Password"
            :type="showPassword ? 'text' : 'password'"
            required
            @click:append-inner="showPassword = !showPassword"
            @keypress.enter="submit"
          ></v-text-field>
          <v-card-actions class="justify-center">
            <v-btn color="light-blue-accent-4" @click="submit">Login</v-btn>
          </v-card-actions>
        </v-form>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script lang="ts" setup>
import { reactive, ref } from "vue";
import { LoginAsync } from "@/services/User";
import { LoginUserInfo } from "@/models/LoginUserInfo";
import { useLoginUserInfoStore } from "@/store/LoginUserInfo";
const loginUserInfoStore = useLoginUserInfoStore();
const userName = ref("");
const password = ref("");
const showPassword = ref(false);
const isShowLoginErrorMessage = ref(false);

const submit = () => {
  if (userName.value.length >= 1 && password.value.length >= 1) {
    const data = LoginAsync(userName.value, password.value);
    data.then((res) => {
      const loginUserInfo = reactive<LoginUserInfo>({
        id: res.data.userId,
        name: userName.value,
        isLogin: res.data.success,
      });
      loginUserInfoStore.setLoginUserInfo(loginUserInfo);
      isShowLoginErrorMessage.value = !res.data.success;
    });
  }
};
</script>
<style></style>
