<template>
  <div id="app">
    <Header/>
    <Main/>
  </div>
</template>

<script>
// Components
import Header from "@/layouts/components/Header.vue"
import Main from "@/layouts/main/Main.vue"

// Plugins
import User from "@/models/model/User/User.js"

export default {
  name: "App",
  components: {
    Header,
    Main
  },
  created() {
    // Kết nối với server
    this.$SignalR.start()
    .then(() => {
      // Kết nối thành công => Cập nhật ConnectionID
      this.$SignalR.invoke("UpdateConnectionID", User.initData())
      .then(res => {
        console.log(res);
      }); 
    }).catch(error => {
      // Kết nối thất bại
      alert("Fail Connection");
      console.log(error);
    });
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
<style>
  @import url('./assets/css/main.css');
</style>
<style lang="scss">
  @import "@/assets/scss/common/common.scss";
</style>
