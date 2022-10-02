import { Friends } from "./Friends";

export interface RecentChatListInfo {
  channelId: string;
  channelName: string;
  channelType: string;
  channelCreatedTime: Date;
  chatInfo: ChatInfo;
}

interface ChatInfo {
  message: string;
  messageTime: Date;
  sendTo: Friends;
  sendBy: Friends;
  messageId: string;
}
