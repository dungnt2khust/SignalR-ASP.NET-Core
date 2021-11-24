<template lang="">
    <div class="full-screen fx-center" :style="customizeStyle(styleCustom)">
        <slot></slot> 
    </div>
</template>
<script>
export default {
    name: "full-screen",
    props: {
        bgColor: {
            type: String,
            default: null
        }
    },
    data() {
        return {
            styleCustom: {
                "background-color": this.bgColor
            }
        }
    },
    computed: {
        
    }
}
</script>
<style lang="scss">
    @import "@/assets/scss/layouts/fullscreen.scss";
</style>