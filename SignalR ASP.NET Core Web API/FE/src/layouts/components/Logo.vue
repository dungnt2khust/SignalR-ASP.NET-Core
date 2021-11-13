<template lang="">
    <div class="logo">
        <div class="logo__icon">
            <i class="fas fa-store"></i>
        </div>
        <span class="logo__shop-name">
            {{ShopName}}
        </span>
    </div>
</template>
<script>
export default {
    name: "Logo",
    data() {
        return {
            ShopName: "EddieShop"
        }
    }
}
</script>
<style lang="scss" scoped>
    @import "@/assets/scss/components/layout/logo.scss";
</style>