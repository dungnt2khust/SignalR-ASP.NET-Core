<template lang="">
  <div class="textarea">
    <textarea
      :rows="row"
      :cols="col"
      :style="customizeStyle(styleCustom)"
      v-on="textareaListeners"
      :value="value"
    />
  </div>
</template>
<script>
export default {
  name: "Textarea",
  props: {
    col: {
      type: Number,
      default: 1
    },
    row: {
      type: Number,
      default: 5
    },
    resize: {
      type: String,
      default: "none"
    },
    width: {
        type: String,
        default: null
    },
    height: {
        type: String,
        default: null
    },
    value: {
      type: [Number, String],
      default: null
    }
  },
  data() {
    return {
      styleCustom: {
        "resize": this.resize,
        "width": this.width,
        "height": this.height
      }
    };
  },
  computed: {
    /**
     * Lắng nghe textarea
     * CreatedBy: NTDUNG (24/11/2021)
     */
    textareaListeners() {
      return Object.assign({}, this.listeners, {
        input: (event) => {
          this.$emit('input', event.target.value);
        }
      })
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/components/textarea/textarea.scss";
</style>
