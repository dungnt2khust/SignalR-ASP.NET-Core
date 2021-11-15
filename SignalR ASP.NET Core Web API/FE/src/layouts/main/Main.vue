<template lang="">
  <div class="main">
    <router-view />
    {{accountData}}
  </div>
</template>
<script>

// Plugins
import User from "@/models/model/User/User.js"

export default {
  name: "Main",
  data() {
    return {
      accountData: {}
    }
  },
  created() {
    if(!this.$account.checkSession()) {
      this.$router.push('login');
    }
  },
  methods: {
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
            .invoke("UpdateConnectionIDUser", User.initData())
            .then(res => {
              console.log(res);
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
        console.log(to.meta.Title);
        document.title = this.$t(to.meta.Title);
      }
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/components/layout/main.scss";
</style>
