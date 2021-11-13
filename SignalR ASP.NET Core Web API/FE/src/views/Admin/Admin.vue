<template>
  <div class="content">
    <div class="message-signalr">
      <div class="message-signalr__main" @keydown.enter="send">
        <ul class="message-signalr__list" >
          <li class="message-signalr__item" v-for="(message, index) in messages" :key="index">
            <span class="username">{{message.user}}</span>
            <span class="userid-admin">{{message.userID ? message.userID : "All"}}</span>
            <span class="message">{{message.message}}</span>
          </li>
        </ul>
        <div class="message-signalr__input">
          <input class="message-signalr__name" type="text" :readonly="readonlyName ? true : false" v-model="userID" placeholder="UserID" />
          <input class="message-signalr__message" type="text" v-model="message" placeholder="Message" />
          <button class="message-signalr__send" @click="send">Send</button>
        </div> 
      </div> 
    </div> 
  </div>
</template>

<script>
const signalR = require("@aspnet/signalr");

export default {
  name: "Admin",
  data() {
    return {
      readonlyName: false,
      message: "",
      connection: "",
      messages: [],
      userID: ""
    };
  },
  methods: {
    send() {
      if (this.name) {
        this.readonlyName = true;
      } else {
        this.readonlyName = false;
      }
      this.connection
        .invoke("SendMessageSpecialUser", this.userID, this.message)
        .catch(error => {
          console.log(error);
        });
      this.message = "";
    }
  },
  created() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:44328/hub/chat")
      .configureLogging(signalR.LogLevel.Information)
      .build();

    this.connection.start().catch(error => {
      console.log(error);
    });
  },
  mounted() {
    this.connection.on("ReceiveMessage", (user, message, userID) => {
        this.messages.push({user, message, userID})
    });
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/views/MessageSignalR/messagesignalr.scss";
</style>