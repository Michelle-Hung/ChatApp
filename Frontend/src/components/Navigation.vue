<template>
  <v-card max-width="auto">
    <v-layout>
      <v-navigation-drawer theme="dark" rail permanent :rail-width="73">
        <v-list-item
          prepend-icon="mdi:mdi-snapchat"
          value="friendList"
          @click="openFriendList"
        ></v-list-item>

        <v-divider></v-divider>

        <v-list nav>
          <v-list-item
            prepend-icon="mdi:mdi-forum"
            value="messages"
            @click="openChatList"
          ></v-list-item>
          <v-list-item
            prepend-icon="mdi:mdi-account-multiple-plus-outline"
            value="create"
          ></v-list-item>
          <v-list-item prepend-icon="mdi:mdi-bell" value="notifactation" link>
            <template v-slot:append>
              <v-badge color="red" dot offset-x="20" offset-y="-15"></v-badge>
            </template>
          </v-list-item>
        </v-list>
        <v-list class="fixedBottom">
          <v-list-item
            prepend-avatar="https://cdn.vuetifyjs.com/images/john.jpg"
          ></v-list-item>
          <v-list-item prepend-icon="mdi:mdi-cog-outline"></v-list-item>
        </v-list>
      </v-navigation-drawer>

      <ChatList v-if="isOpenChatList" />

      <FriendList v-if="isOpenFriendList" />

      <v-main style="height: 1000px"></v-main>
    </v-layout>
  </v-card>
</template>

<script lang="ts" setup>
import { ref } from "@vue/reactivity";
import FriendList from "@/components/FriendList.vue";
import ChatList from "@/components/ChatList.vue";
const searchText = ref("");
const search = () => {
  console.log(`search text:: ${searchText.value}`);
};
const isOpenChatList = ref(false);
const isOpenFriendList = ref(false);
const openChatList = () => {
  isOpenChatList.value = !isOpenChatList.value;
  if (isOpenChatList.value === true) {
    isOpenFriendList.value = false;
  }
};
const openFriendList = () => {
  isOpenFriendList.value = !isOpenFriendList.value;
  if (isOpenFriendList.value === true) {
    isOpenChatList.value = false;
  }
};
</script>
<style>
.fixedBottom {
  position: fixed;
  bottom: 0;
  width: 100%;
}
</style>
