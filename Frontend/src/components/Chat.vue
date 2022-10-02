<template>
  <v-container sm="12" xs="6" fluid>
    <v-card class="mx-auto overflow-auto" color="grey-lighten-4" height="100%">
      <div style="height: 950px">
        <v-card-avatar>
          <v-avatar>
            <img src="https://cdn.vuetifyjs.com/images/john.jpg" alt="John" />
          </v-avatar>
          {{ myNickName }}
        </v-card-avatar>
        <v-row
          v-for="(chatContent, index) in chatContentList"
          :key="index"
          class="mt-5 pl-3"
          :class="
            myNickName === chatContent.userName ? 'flex-row-reverse pr-3' : ''
          "
        >
          <v-card-avatar>
            <v-avatar size="small">
              <img src="https://cdn.vuetifyjs.com/images/john.jpg" alt="John" />
            </v-avatar>
          </v-card-avatar>
          <v-card>
            <v-card-text>
              {{ chatContent.message }}
            </v-card-text>
          </v-card>
        </v-row>
        <v-card-actions>
          <v-row class="mt-5 px-2">
            <v-text-field
              v-model="newMessage"
              variant="filled"
              label="Message"
              placeholder="Type a message here"
              type="text"
              clearable
              @click:clear="clearMessage"
              @keypress.enter="sendMessage"
            ></v-text-field>
            <v-btn
              icon="mdi:mdi-send"
              color="light-blue-accent-4"
              @click="sendMessage"
              variant="plain"
            />
          </v-row>
        </v-card-actions>
      </div>
    </v-card>
  </v-container>
</template>

<script lang="ts" setup>
import { ref } from "vue";
import { signalrInit } from "../services/SignalR";
import { useLoginUserInfoStore } from "@/store/LoginUserInfo";
const { connection, chatContentList } = signalrInit();
const loginUserInfoStore = useLoginUserInfoStore();

const newMessage = ref("");
const myNickName = loginUserInfoStore.$state.loginUserInfo?.name;
const sendMessage = () => {
  if (newMessage.value !== "") {
    connection
      .invoke("sendMessageAsync", newMessage.value, myNickName)
      .catch((error) => {
        console.log(error);
      });
    newMessage.value = "";
  }
};

const clearMessage = () => {
  newMessage.value = "";
};
</script>

<style></style>
