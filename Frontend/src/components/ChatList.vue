<template>
  <v-navigation-drawer theme="dark" :width="400">
    <v-list nav>
      <v-list-item>
        <v-list-item-header>
          <v-card>
            <v-row>
              <v-card-title>Recent</v-card-title>
              <v-card-actions class="d-flex justify-end">
                <v-btn icon>
                  <v-icon>mdi:mdi-dots-horizontal</v-icon>
                </v-btn>
              </v-card-actions>
            </v-row>
          </v-card>
          <v-text-field
            label="Search for people or group"
            prepend-inner-icon="mdi:mdi-magnify"
            clearable
            v-model="searchText"
            @keypress.enter="filterRecentChatInfos"
            hide-details="auto"
          ></v-text-field>
        </v-list-item-header>
      </v-list-item>
      <div
        v-for="recentChatInfo in filterRecentChatInfos()"
        v-bind:key="recentChatInfo.channelId"
      >
        <v-list-item height="90" v-on:click="openChatRoom(recentChatInfo)">
          <v-list-item-avatar left>
            <v-avatar size="small">
              <v-img
                src="https://randomuser.me/api/portraits/women/75.jpg"
              ></v-img>
            </v-avatar>
          </v-list-item-avatar>
          <v-list-item-header>
            <v-list-item-title>{{
              recentChatInfo.channelName
            }}</v-list-item-title>
            <v-list-item-subtitle>{{
              recentChatInfo.chatInfo.message
            }}</v-list-item-subtitle>
          </v-list-item-header>
        </v-list-item>
        <v-divider />
      </div>

      <!-- <v-list-item height="90" value="2">
        <v-list-item-avatar left>
          <v-avatar size="small">
            <v-img
              src="https://randomuser.me/api/portraits/women/75.jpg"
            ></v-img>
          </v-avatar>
        </v-list-item-avatar>
        <v-list-item-header>
          <v-list-item-title>Nancy</v-list-item-title>
          <v-list-item-subtitle>Hi</v-list-item-subtitle>
        </v-list-item-header>
      </v-list-item>
      <v-divider />
      <v-list-item height="90">
        <v-list-item-avatar left>
          <v-avatar size="small">
            <v-img
              src="https://randomuser.me/api/portraits/women/75.jpg"
            ></v-img>
          </v-avatar>
        </v-list-item-avatar>
        <v-list-item-header>
          <v-list-item-title>Maggie</v-list-item-title>
          <v-list-item-subtitle>Hi</v-list-item-subtitle>
        </v-list-item-header>
      </v-list-item>
      <v-divider /> -->
    </v-list>
  </v-navigation-drawer>
</template>

<script lang="ts" setup>
import { RecentChatListInfo } from "@/models/ChatInfo";
import { useLoginUserInfoStore } from "@/store/LoginUserInfo";
import { useChatRoomInfoStore } from "@/store/ChatRoomInfo";
import { useTogglesStore } from "@/store/TogglesStore";
import chatApi from "@/services/Chat";
import { reactive, ref } from "@vue/reactivity";
import { ChatRoomInfo } from "@/models/ChatRoomInfo";

const loginUserInfoStore = useLoginUserInfoStore();
let recentChatInfos = ref<Array<RecentChatListInfo>>([]);
chatApi
  .GrtRecentChatList(loginUserInfoStore.$state.loginUserInfo.id)
  .then((response) => {
    recentChatInfos.value = response.data;
  });

const searchText = ref("");
const filterRecentChatInfos = () => {
  return recentChatInfos.value.filter((x) =>
    x.channelName.toLowerCase().includes(searchText.value.toLowerCase())
  );
};

const openChatRoom = (currentChatInfo: RecentChatListInfo) => {
  const sendToUserInfo =
    currentChatInfo.chatInfo.sendBy.userId !==
    loginUserInfoStore.$state.loginUserInfo.id
      ? currentChatInfo.chatInfo.sendBy
      : currentChatInfo.chatInfo.sendTo;
  const chatRoomInfo = reactive<ChatRoomInfo>({
    channelId: currentChatInfo.channelId,
    channelName: currentChatInfo.channelName,
    channelType: currentChatInfo.channelType,
    sendTo: sendToUserInfo,
  });
  const chatRoomInfoStore = useChatRoomInfoStore();
  chatRoomInfoStore.setchatRoomInfo(chatRoomInfo);

  const togglesStore = useTogglesStore();
  togglesStore.setIsOpenChatRoom(!togglesStore.$state.isOpenChatRoom);
};
</script>
<style></style>
