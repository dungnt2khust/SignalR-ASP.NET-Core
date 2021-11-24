<template lang="">
    <div class="button" :class="`button--${type}`" :style="customizeStyle(style)">
        {{label}}
    </div>
</template>
<script>
// Library
import commonFunction from "@/mixins/commonFunction.js"

export default {
    name: "Button",
    mixins: [commonFunction],
    props: {
        label: {
            type: String,
            default: "Button"
        },
        type: {
            type: Number,
            default: 0
        },
        width: {
            type: String,
            default: null
        },
        txtPos: {
            type: String,
            default: null
        }
    },
    data() {
        return {
            style: {
                'width': this.width, 
                'text-align': this.txtPos
            } 
        }
    },
    computed: {
    }
}
</script>
<style lang="scss">
    @import "@/assets/scss/components/button/button.scss";
</style>