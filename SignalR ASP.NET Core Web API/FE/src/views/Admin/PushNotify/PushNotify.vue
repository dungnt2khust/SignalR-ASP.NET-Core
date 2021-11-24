<template lang="">
  <BaseContentArea class="fx-row aln-i-center jus-c-center">
    <template v-slot:content>
      <BaseContentFrame bgColor="#ccc" width="300px">
        <div class="fx-row wrap">
          <ed-row class="fx-col">
            <ed-label value="Tiêu đề" />
            <ed-input v-model="title"/>
          </ed-row>
          <ed-row class="fx-col">
            <ed-label value="Nội dung" />
            <ed-textarea  v-model="content" :col="10" :row="5" />
          </ed-row>
          <ed-row>
            <ed-button label="Send" @click.native="sendNotify" :type="1" />
          </ed-row>
        </div>
      </BaseContentFrame>
      <ListUser v-model="listUsers"/>
    </template>
  </BaseContentArea>
</template>
<script>
// Components
import ListUser from "@/layouts/listuser/ListUser.vue";
// Library
import UserAPI from "@/api/Components/User/User.js";

export default {
  name: "PushNotify",
  components: {
    ListUser
  },
  data() {
    return {
      listUsers: [],
      title: "Thông báo", 
      content: "Nội dung"
    };
  },
  mounted() {
    // Khởi tạo hàm nhận thông báo từ server
  },
  methods: { 
    /**
     * Gửi tin nhắn đến người dùng khác
     * CreatedBy: NTDUNG (14/11/2021)
     */
    sendNotify() {
      var userSent = this.$store.state.accountData.Data;
      var userReceiveIDs = this.listUsers.filter(user => {return user.checked == true}).map(user => user.UserID);

      if (userReceiveIDs.length)
        this.$SignalR
          .invoke("SendNotifyToUsers", userSent, userReceiveIDs, {Title: this.title, Content: this.content})
          .then(res => {
            this.title = "Thông báo";
            this.content = "Nội dung";
          })
          .catch(error => {
            console.log(error);
          });
      else 
        alert("Bạn phải chọn một người dùng trước khi gửi !!!");
    } 
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/views/admin/pushnotify/pushnotify.scss";
</style>
