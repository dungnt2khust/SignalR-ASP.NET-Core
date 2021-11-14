<template>
  <div class="message-signalr">
    <div class="message-signalr__main" @keydown.enter="send">
      <ul ref="listMessages" class="message-signalr__list defaultScrollbar" >
        <li class="message-signalr__item" v-for="(message, index) in messages" 
        :class="{'item--other': message.userID != userID}" :key="index">
          <span class="username">{{message.user}}</span>
          <span class="message">{{message.message}}</span>
          <span class="message">{{message.userID}}</span>
        </li>
      </ul>
      <div class="message-signalr__input">
        <span class="userid">UserID: {{userID}}</span>
        <input class="message-signalr__name" type="text" :readonly="readonlyName ? true : false" v-model="name" placeholder="Name" />
        <input class="message-signalr__message" type="text" v-model="message" placeholder="Message" />
        <button class="message-signalr__send" @click="send">Send</button>
      </div> 
    </div> 
  </div> 
</template>

<script>

const signalR = require("@aspnet/signalr");

export default {
  data() {
    return {
      readonlyName: false,
      name: "",
      message: "",
      connection: "",
      messages: []
    };
  },
  methods: {
    /**
     * Gửi tin nhắn đến người dùng khác
     * CreatedBy: NTDUNG (14/11/2021)
     */
    send() {
      if (this.name) {
        this.readonlyName = true;
      } else {
        this.readonlyName = false;
      }
      this.connection
        .invoke("SendMessage", this.name, this.message)
        .catch(error => {
          console.log(error);
        });
      this.message = "";
    },
    /**
     * Gửi tin nhắn đến Admin
     * CreatedBy: NTDUNG (14/11/2021)
     */
    sendToAdmin() {

    }
  },
  created() {
    
  },
  mounted() {
    
  }
};
</script>
<style lang="scss">
  @import "@/assets/scss/views/MessageSignalR/messagesignalr.scss";
</style>