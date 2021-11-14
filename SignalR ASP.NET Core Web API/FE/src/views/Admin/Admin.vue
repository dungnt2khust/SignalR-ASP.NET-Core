<template>
  <div class="message-signalr">
    <div class="message-signalr__main" @keydown.enter="send">
      <ul class="message-signalr__list defaultScrollbar" >
        <li class="message-signalr__item" v-for="(message, index) in messages" :key="index">
          <span class="username">{{message.user}}</span>
          <span class="message">{{message.message}}</span>
        </li>
      </ul>
      <div class="message-signalr__input">
        <input class="message-signalr__name" type="text" v-model="userName" placeholder="UserName" />
        <input class="message-signalr__message" type="text" v-model="message" placeholder="Message" />
        <button class="message-signalr__send" @click="send">Send</button>
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
      userName: "",
      message: "",
      messages: [],
    };
  },
  mounted() {
    this.receiveDataSignalR();
  },
  methods: {
    /**
     * Nhận dữ liệu signalR gửi từ server
     * CreatedBy: NTDUNG (14/11/2021)
     */
    receiveDataSignalR() {
      // Nhận tin nhắn
      this.$SignalR.on("ReceiveMessage", (user, message) => {
        this.messages.push({user, message});
        this.$nextTick(() => {
          var lastMessage = this.$refs.listMessages.querySelector('li:last-child');
          lastMessage.scrollIntoView();
        });
      });
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/views/MessageSignalR/messagesignalr.scss";
</style>