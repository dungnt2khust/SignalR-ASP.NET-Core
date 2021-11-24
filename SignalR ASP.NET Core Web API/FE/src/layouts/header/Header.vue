<template lang="">
  <div class="header pos-relative">
    <div class="header__main">
      <Logo />
    </div>
    <div class="pos-absolute fx-s-between" style="top: 0; right: 0;">
      <div v-if="$store.state.accountData.AccountType" style="color: #fff; font-family: sans-serif;">
          {{$store.state.accountData.Data.DisplayName}}
      </div>
      <ed-button
        v-if="!$store.state.accountData.AccountType"
        label="Login"
        @click.native="login"
        :type="1"
      />
      <ed-button
        v-if="!$store.state.accountData.AccountType"
        label="Register"
        :type="2"
      />
      <ed-button v-else label="Logout" @click.native="logout" :type="1" />
    </div>
    <nav-bar />
  </div>
</template>
<script>
// Components
import NavBar from "@/layouts/navbar/NavBar.vue";
import Logo from "@/layouts/logo/Logo.vue";

export default {
  name: "Header",
  components: {
    NavBar,
    Logo
  },
  methods: {
    /**
     * Đăng xuất
     * CreatedBy: NTDUNG (23/11/2021)
     */
    logout() {
      this.$router.push("/login");
      this.$store.state.accountData.AccountType = 0;
      this._removeLocalStorage("Session");
    },
    login() {
      this.$router.push("/login");
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/layouts/header/header.scss";
</style>
