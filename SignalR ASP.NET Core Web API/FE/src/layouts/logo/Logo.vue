<template lang="">
    <div class="logo" :style="customizeStyle(styleCustom)">
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
    props: {
        bgColor: {
            type: String,
            default: null
        },
        txtColor: {
            type: String,
            default: null
        },
        txtSize: {
            type: String,
            default: null
        }
    },
    data() {
        return {
            ShopName: "EddieShop",
            styleCustom: {
                "background-color": this.bgColor,
                "color": this.txtColor,
                "font-size": this.txtSize
            }
        }
    },
    computed: {
        
    }
}
</script>
<style lang="scss" scoped>
    @import "@/assets/scss/layouts/logo/logo.scss";
</style>