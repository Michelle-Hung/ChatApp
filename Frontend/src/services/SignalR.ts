import { ChatContent } from "@/models/ChatContent";
import { HubConnectionState, HubConnectionBuilder } from "@microsoft/signalr";
import { reactive } from "vue";
export function signalrInit() {
  const chatContentList = reactive<Array<ChatContent>>([]);
  const connection = new HubConnectionBuilder()
    .withUrl(`${process.env.VUE_APP_API_URL}/ChatHub`)
    .build();
  connection
    .start()
    .then(() => {
      if (connection.state !== HubConnectionState.Connected) {
        console.log(connection.state);
      }
      connection.on("ReceiveMessage", (message: string, userName: string) => {
        const chatContent: ChatContent = {
          message: message,
          userName: userName,
        };
        chatContentList.push(chatContent);
        console.log(`receive message :: ${JSON.stringify(chatContentList)}`);
      });
    })
    .catch((err) => {
      console.log(`Connection Error ${err}`);
    });
  connection.onclose(() => {
    console.log("Connection Destroy");
  });

  return { chatContentList, connection };
}
