<template>
  <div id="app">
    <Header/>
    <Main/>
  </div>
</template>

<script>
// Components
import Header from "@/layouts/header/Header.vue"
import Main from "@/layouts/main/Main.vue"

// Plugins

export default {
  name: "App",
  components: {
    Header,
    Main
  }
};
</script>
<style>
  @import url('./assets/css/main.css');
</style>
<style lang="scss">
  @import "@/assets/scss/common/common.scss";
</style>
