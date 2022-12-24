import { Friends } from "./Friends";

export interface ChatRoomInfo {
  channelId: string;
  channelName: string;
  channelType: string;
  sendTo: Friends;
}
