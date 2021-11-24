<template lang="">
  <div class="base-content-frame defaultScrollbar" :style="customizeStyle(styleCustom)">
    <slot></slot>
  </div>
</template>
<script>

export default {
  name: "BaseContentFrame",
  props: {
    width: {
      type: String,
      default: null
    },
    minWidth: {
      type: String,
      default: null
    },
    maxWidth: {
      type: String,
      default: null
    },
    height: {
      type: String,
      default: null
    },
    minHeight: {
      type: String,
      default: null
    },
    maxHeight: {
      type: String,
      default: null
    },
    bgColor: {
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
    border: {
      type: String,
      default: null
    }
  },
  data() {
    return {
      styleCustom: {
        "width": this.width,
        "min-width": this.minWidth,
        "max-width": this.maxWidth,
        "height": this.height,
        "min-height": this.minHeight,
        "max-height": this.maxHeight,
        "background-color": this.bgColor,
        "border-radius": this.borderRad,
        "top": this.top,
        "bottom": this.bottom,
        "left": this.left,
        "right": this.right,
        "border": this.border
      }
    };
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/layouts/basecontentframe/basecontentframe.scss";
</style>
