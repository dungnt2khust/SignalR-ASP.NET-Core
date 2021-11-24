<template lang="">
  <div class="icon" :style="customizeStyle(styleCustom)" :class="`mi-${size}`">
    <div :class="iconCls ? iconCls : ''">
        <slot></slot>
    </div>
  </div>
</template>
<script>
// Library
import commonFunction from "@/mixins/commonFunction.js";

export default {
  name: "Icon",
  mixins: [commonFunction],
  props: {
    iconCls: {
      type: String,
      default: null
    },
    size: {
      type: Number,
      default: null
    },
    bgColor: {
      type: String,
      default: null
    },
    width: {
        type: String,
        default: null
    },
    height: {
        type: String,
        default: null
    },
    borderRad: {
        type: String,
        default: null
    },
    top: {
        type: String,
        default: null
    },
    bottom: {
        type: String,
        default: null
    },
    left: {
        type: String,
        default: null
    },
    right: {
        type: String,
        default: null
    },
    txtSize: {
        type: String,
        default: null
    },
    txtStyle: {
        type: String,
        default: "sans-serif"
    },
    txtColor: {
        type: String,
        default: null
    },
    translate: {
        type: String,
        default: null
    }
  },
  data() {
    return {
      styleCustom: {
        "background-color": this.bgColor,
        "width": this.width,
        "height": this.height,
        "border-radius": this.borderRad,
        "top": this.top,
        "bottom": this.bottom,
        "left": this.left,
        "right": this.right,
        "font-size": this.txtSize,
        "font-family": this.txtStyle,
        "color": this.txtColor,
        "transform": `translate(${this.translate})`
      }
    };
  }
};
</script>
<style lang=""></style>
