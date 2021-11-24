<template>
  <div class="message-signalr">
    <div class="message-signalr__main" style="width: 500px;" @keydown.enter="send">
      <ul ref="listMessages" class="message-signalr__list defaultScrollbar">
        <li
          class="message-signalr__item"
          v-for="(message, index) in messages"
          :class="{
            'item--other':
              message.User.ConnectionID !=
              $store.state.accountData.Data.ConnectionID
          }"
          :key="index"
        >
          <span class="username">{{ message.User.DisplayName }}</span>
          <span class="message">{{ message.Message }}</span>
        </li>
      </ul>
      <div class="message-signalr__input">
        <div class="fx-row m-b-20">
          <ed-row class="fx-row gut-m-2"> 
            <ed-col :colW="12" class="gut-p-2">
              <ed-input
                class="message-signalr_name"
                v-model="message"
                :value="message"
                placeholder="Message"
              />
            </ed-col>
          </ed-row>
        </div>
        <ed-button label="Send" @click.native="send" />
      </div>
    </div>
    <BaseContentFrame class="m-l-30" width="400px" height="100%" bgColor="#ccc">
      <div class="list-user defaultScrollbar">
        <div
          v-for="(user, index) in listUsers"
          class="list-user__item fx-row aln-i-center jus-c-sbtn m-10 p-l-10"
          :key="index"
        >
          <div class="fx-row flex-1">
            <div class="list-user__code m-r-10">{{ user.Code }}</div>
            <div class="list-user__name">{{ user.DisplayName }}</div>
          </div>
          <div @click="checkUser(index)">
            <div v-if="user.checked" class="mi-check cur-p m-10"></div>
            <div v-else class="mi-uncheck cur-p m-10"></div>
          </div>
        </div>
        <div v-if="!listUsers.length">
          Không có user nào
        </div>
      </div>
    </BaseContentFrame>
  </div>
</template>

<script>
// Library
import UserAPI from "@/api/Components/User/User.js";

export default {
  data() {
    return {
      message: "",
      messages: [],
      listUsers: []
    };
  },
  mounted() {
    // Khai báo các hàm nhận thông báo từ server
    this.receiveMessage();
    // Lấy dữ liệu toàn bộ user
    this.getListUsers();
  },
  methods: {
    /**
     * Lấy danh sách users
     * CreatedBy: NTDUNG (24/11/2021)
     */
    getListUsers() {
      UserAPI.getAll()
        .then(res => {
          var users = res.data.Data;
          users = users.filter(user => {
            return user.UserID != this.$store.state.accountData.AccountId;
          });
          this.listUsers = users;
        })
        .catch(err => {
          console.log(err);
        });
    },
    /**
     * Nhận tin nhắn
     * CreatedBy: NTDUNG (24/11/2021)
     */
    receiveMessage() {
      this.$SignalR.on("ReceiveMessage", (user, message) => {
        this.messages.push({ User: user, Message: message });
      });
    },
    /**
     * Gửi tin nhắn đến người dùng khác
     * CreatedBy: NTDUNG (14/11/2021)
     */
    send() {
      var userSent = this.$store.state.accountData.Data;
      var userReceiveIDs = this.listUsers.filter(user => {return user.checked == true}).map(user => user.UserID);

      if (userReceiveIDs.length)
        this.$SignalR
          .invoke("SendMessageToUsers", userSent, userReceiveIDs, this.message)
          .then(res => {
            this.messages.push({ User: userSent, Message: this.message });
            this.message = "";
          })
          .catch(error => {
            console.log(error);
          });
      else 
        alert("Bạn phải chọn một người dùng trước khi gửi !!!");
    },
    /**
     * Gửi tin nhắn đến Admin
     * CreatedBy: NTDUNG (14/11/2021)
     */
    sendToAdmin() {}, 
    /**
     * Chọn user
     * CreatedBy: NTDUNG (24/11/2021)
     */
    checkUser(index) {
      this.$set(this.listUsers[index], 'checked', !this.listUsers[index].checked);
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/views/MessageSignalR/messagesignalr.scss";
@import "@/assets/scss/layouts/listuser/listuser.scss";
</style>
