<template lang="">
    <div class="navbar">
        <div v-for="(navbar, index) in navbarData" 
            @click="navBarItemClick(index)" class="navbar__item" 
            :class="{'selected': index == 0}":key="index">
            {{ $t(navbar.Title) }}
        </div>
    </div>
</template>
<script>
import NavbarData from "@/layouts/menu/menu.js"

export default {
    name: "NavBar",
    data() {
        return { 
            navbarData: NavbarData
        }
    },
    methods: {
        /**
         * Xử lý click vào item trên navbar
         * @param {Number} index
         * CreatedBy: NTDUNG(02/11/2021)
         */
        navBarItemClick(index) {
            // this.$popup.confirmDelete(this.navBarData[index]);
            this.$router.push(this.navbarData[index].Path);
        }
    }
}
</script>
<style lang="scss" scoped>
    @import "@/assets/scss/components/layout/navbar.scss";
</style>