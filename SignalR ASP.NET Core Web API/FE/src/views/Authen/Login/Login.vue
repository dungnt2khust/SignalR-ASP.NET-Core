<template lang="">
  <div class="login">
    <ed-popup title="Đăng nhập">
      <template v-slot:header>
        <ed-logo txtColor="#fff" txtSize="24px" bgColor="#12007B" />
      </template>
      <template v-slot:content>
        <div class="fx-wrap p-t-20 p-b-20">
          <ed-row class="fx-col">
            <ed-label value="Tài khoản" />
            <ed-input v-model="accountName" :value="accountName" />
          </ed-row>
          <ed-row class="fx-col">
            <ed-label value="Mật khẩu" />
            <ed-input v-model="password" :value="password" type="password" />
          </ed-row>
          <ed-row class="m-t-20">
            <ed-button
              class="m-r-10"
              label="Đăng nhập"
              txtPos="center"
              @click.native="login"
              :type="2"
            >
            </ed-button>
            <ed-button class="m-r-10" label="Đăng kí" :type="1"> </ed-button>
            <ed-button label="Khách" @click.native="guestMode" :type="0">
            </ed-button>
          </ed-row>
        </div>
      </template>
    </ed-popup>
  </div>
</template>
<script>
// Library
import { AccountType } from "@/models/enum/AccountType.js";
import {ConnectionState} from "@/models/enum/ConnectionState.js"

export default {
  name: "Login",
  data() {
    return {
      showPassword: false,
      password: "",
      accountName: ""
    };
  },
  mounted() {
    // Đóng kết nối cũ nếu có
    if (this.$SignalR.connection.connectionState == ConnectionState.CONNECTED) {
      this.$SignalR.stop();
    }
  },
  methods: {
    /**
     * Đăng nhập
     * CreatedBy: NTDUNG (22/11/2021)
     */
    login() {
      this.$account
        .checkValidAccount({ Name: this.accountName, PassWord: this.password })
        .then(res => {
          if (res.data.Data.AccountType) {
            this.$store.state.accountData = res.data.Data;
            this._setLocalStorage(
              "Session",
              res.data.Data.Data.SessionID
            );
            if (this.$route.path != "/home" && this.$route.path != "/admin/dashboard") {
              switch(this.$store.state.accountData.AccountType) {
                case AccountType.ADMIN:
                  this.$router.push("/admin/dashboard");
                  break;
                case AccountType.USER:
                  this.$router.push("/home");
              }
            }
          } else {
            alert("Tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại.");
          }
        })
        .catch(res => {
          console.log(res);
        });
    },
    guestMode() {
        this.$router.push('/home');
    } 
  }
};
</script>
<style lang="scss">
.test {
  height: 50px;
  width: 100%;
  background: red;
}
</style>
