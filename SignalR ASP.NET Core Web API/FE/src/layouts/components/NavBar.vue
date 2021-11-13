<template lang="">
    <div class="navbar">
        <div v-for="(navbar, index) in navBarData" @click="navBarItemClick(index)" class="navbar__item" :key="index">
            {{ navbar }}
        </div>
    </div>
</template>
<script>
export default {
    name: "NavBar",
    data() {
        return {
            navBarData: [
                'Trang chủ',
                'Đơn hàng',
                'Giỏ hàng',
                'Chăm sóc khách hàng',
                'Bảo trì',
                'ChatHub'
            ]
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
            if (index == this.navBarData.length - 1) {
                this.$router.push('MessageSignalR');
            }
            if (index == 0) {
                this.$router.push('Home');
            }
        }
    }
}
</script>
<style lang="scss" scoped>
    @import "@/assets/scss/components/layout/navbar.scss";
</style>