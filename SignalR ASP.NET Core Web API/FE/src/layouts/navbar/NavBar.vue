<template lang="">
  <div class="navbar fx-row jus-c-sbtn">
    <div class="navbar__left fx-row">
      <div
        v-for="(navbar, index) in $store.state.navBar"
        @click="navBarItemClick(index)"
        class="navbar__item"
        :class="{ selected: $route.path == navbar.Path }"
        :to="navbar.Path"
        :key="index"
      >
        {{ $t(navbar.Title) }}
      </div>
    </div>
    <div class="navbar__right fx-row aln-i-center cur-p">
      <Notify/>
    </div>
  </div>
</template>
<script>
// Components
import Notify from "@/layouts/notify/Notify.vue";

export default {
  name: "NavBar", 
  components: {
    Notify
  },
  methods: {
    /**
     * Xử lý click vào item trên navbar
     * @param {Number} index
     * CreatedBy: NTDUNG(02/11/2021)
     * ModifiedBy: NTDUNG (23/11/2021)
     */
    navBarItemClick(index) {
      if (this.$store.state.navBar[index].Path != this.$route.path)
        this.$router.push(this.$store.state.navBar[index].Path);
    }
  }
};
</script>
<style lang="scss" scoped>
@import "@/assets/scss/layouts/navbar/navbar.scss";
</style>
