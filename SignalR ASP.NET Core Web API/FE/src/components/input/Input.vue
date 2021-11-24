<template lang="">
  <div class="input" :style="customizeStyle(styleCustom)">
    <input
      :type="typeTemp"
      :value="value"
      :placeholder="placeholder"
      v-on="inputListeners"
    />
    <div
      v-if="type == 'password'"
      @click="togglePassword"
      class="show-password"
    >
      <div v-if="showPassword" class="mi-hidden"></div>
      <div v-else class="mi-show"></div>
    </div>
  </div>
</template>
<script>

export default {
  name: "Input",
  props: {
    width: {
      type: String,
      default: null
    },
    type: {
      type: String,
      default: "text"
    },
    value: {
      type: [Number, String],
      default: null
    },
    placeholder: {
      type: [Number, String],
      default: null
    }
  },
  data() {
    return {
      styleCustom: {
        width: this.width
      },
      showPassword: false,
      typeTemp: this.type
    };
  },
  computed: {
    /**
     * Lắng nghe sự kiện trên input
     */
    inputListeners() {
      return Object.assign({}, this.$listener, {
        input: event => {
          this.$emit("input", event.target.value);
        }
      });
    } 
  },
  methods: {
    /**
     * Bật tắt hiển thị mật khẩu
     * CreatedBy: NTDUNG (20/11/2021)
     */
    togglePassword() {
      this.showPassword = !this.showPassword;
      this.typeTemp = this.typeTemp == "text" ? "password" : "text";
    }
  },
  watch: {
    value(val) {
      if (this.type == "password" && (val + "").length > 20) {
        alert("Mặt khẩu tối đa là 20 kí tự");
      }
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/components/input/input.scss";
</style>
