<template lang="">
  <div class="main">
    <router-view />
  </div>
</template>
<script>

// Plugins
import {AccountType} from "@/models/enum/AccountType.js";

export default {
  name: "Main",
  data() {
    return {
    }
  },
  mounted() {
    // Kiểm tra session khi vào trang web
    this.checkSession();
  },
  methods: {
    /**
     * Kiểm tra phiên đăng nhập
     * CreatedBy: NTDUNG (19/11/2021)
     */
    checkSession() {
      if (this.$storage._getLocalStorage("Session")) {
        this.$account.checkSession()
          .then(res => {
            if (res.data.Data.AccountType) {
              this.$account.AccountData = res.data.Data;              
              this.connectServer();
            } else {
              this.$account.AccountData = {
                AccountType: AccountType.GUEST,
                Data: {}
              }
              this.$router.push('/login');
            }
          })
          .catch(err => {
            console.log(err);
          })
      } else {
        this.$account.AccountData = {
          AccountType: AccountType.GUEST,
          Data: {}
        }
        this.$router.push('/login');
      }
    },
    /**
     * Kết nối với server
     * CreatedBy: NTDUNG (13/11/2021)
     */
    connectServer() {
      // Kết nối với server
      this.$SignalR
        .start()
        .then(() => {
          // Kết nối thành công => Cập nhật ConnectionID
          this.$SignalR
            .invoke("UpdateConnectionID", this.$account.AccountData)
            .then(res => {
              alert("Chào mừng " + this.$account.AccountData.Data.DisplayName);
              this.$router.push('/home');
            });
        })
        .catch(error => {
          // Kết nối thất bại
          alert("Fail Connection");
          console.log(error);
        });
    }
  },
  watch: {
    $route: {
      immediate: true,
      deep: true,
      handler(to, from) {
        document.title = this.$t(to.meta.Title);
      }
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/layouts/main.scss";
</style>
