<template lang="">
    <div class="navbar">
        <div v-for="(navbar, index) in navbarData" 
            @click="navBarItemClick(index)" class="navbar__item" 
            :class="{'selected': $route.path == navbar.Path}":key="index">
            {{ $t(navbar.Title) }}
        </div>
    </div>
</template>
<script>

export default {
    name: "NavBar",
    props: {
        navbarData: {
            type: Array,
            default: function() {
                return [];
            }
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
    },
    watch: {
        $route(val) {
            console.log(val);
        }
    }
}
</script>
<style lang="scss" scoped>
    @import "@/assets/scss/layouts/navbar.scss";
</style>