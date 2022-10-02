<template>
  <v-navigation-drawer theme="dark" :width="400">
    <v-list nav>
      <v-list-item>
        <v-list-item-header>
          <v-card>
            <v-row>
              <v-card-title>Friends</v-card-title>
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
            hide-details="auto"
          ></v-text-field>
        </v-list-item-header>
      </v-list-item>
      <v-list-item
        v-for="(friend, index) in friendContacts"
        v-bind:key="friend.userId"
        height="60"
        v-bind:value="index"
      >
        <v-list-item-avatar left>
          <v-avatar size="small">
            <v-img
              src="https://randomuser.me/api/portraits/women/75.jpg"
            ></v-img>
          </v-avatar>
        </v-list-item-avatar>
        <v-list-item-header>
          <v-list-item-title>{{ friend.displayName }}</v-list-item-title>
        </v-list-item-header>
      </v-list-item>
      <v-divider />
    </v-list>
  </v-navigation-drawer>
</template>

<script setup lang="ts">
import { ref } from "@vue/reactivity";
import friendApi from "@/services/Friend";
import { Friends } from "@/models/Friends";
import { useLoginUserInfoStore } from "@/store/LoginUserInfo";
import { storeToRefs } from "pinia";

let searchText = ref("");
const loginUserInfoStore = useLoginUserInfoStore();
const { loginUserInfo } = storeToRefs(loginUserInfoStore);

let friendContacts = ref<Array<Friends>>([]);
friendApi.GetContacts(loginUserInfo.value.id).then((response) => {
  friendContacts.value = response.data.friends;
});
</script>
<style></style>
