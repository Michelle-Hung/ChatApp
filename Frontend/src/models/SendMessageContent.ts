import { Friends } from "./Friends";

export interface SendMessageContent {
  sendBy: Friends;
  sendTo: Friends;
  roomId: string;
  message: string;
}
