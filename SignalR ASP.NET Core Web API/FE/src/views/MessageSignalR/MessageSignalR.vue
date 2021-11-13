<template>
  <div class="content">
    <div class="message-signalr">
        <div class="message-signalr__main">
            <input class="message-signalr__name" type="text" v-model="name" placeholder="Name" />
            <input class="message-signalr__message" type="text" v-model="message" placeholder="Message" />
            <button class="message-signalr__send" @click="send">Send</button>
            <ul class="mesage-signalr__list" v-for="message in messages">
                <li>{{message.user}} {{message.message}}</li>
            </ul>
        </div> 
    </div> 
  </div>
</template>

<script>
const signalR = require("@aspnet/signalr");

export default {
  data() {
    return {
      name: "",
      message: "",
      connection: "",
      messages: []
    };
  },
  methods: {
    send() {
      this.connection
        .invoke("SendMessage", this.name, this.message)
        .catch(error => {
          console.log(error);
        });
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
    this.connection.on("ReceiveMessage", (user, message) => {
      this.messages.push({user, message})
    });
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/views/MessageSignalR/messagesignalr.scss";
</style>