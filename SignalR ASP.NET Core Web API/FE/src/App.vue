<template>
  <div id="app">
    <Header/>
    <router-view/>
  </div>
</template>

<script>
import Header from "@/layouts/components/Header.vue";

export default {
  name: "App",
  components: {
    Header
  } 
};
</script>
<style>
  @import url('./assets/css/main.css');
</style>
<style lang="scss">
  @import "@/assets/scss/common/common.scss";
</style>
