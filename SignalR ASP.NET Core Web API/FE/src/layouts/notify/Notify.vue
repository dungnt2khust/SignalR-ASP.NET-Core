<template lang="">
  <div class="notify">
    <ed-icon
      class="pos-relative"
      :size="30"
      iconCls="mi-notify-white "
      @click.native="showNotify = !showNotify"
    >
      <ed-icon
        v-if="listNotify.length"
        class="pos-absolute"
        bgColor="red"
        top="0"
        right="0"
        translate="10%, -10%"
        borderRad="8px"
        txtSize="12px"
        txtColor="#fff"
        :size="18"
      >
        {{listNotify.length}}
      </ed-icon>
      <BaseContentFrame
        v-if="showNotify"
        class="pos-absolute p-10"
        width="300px"
        height="400px"
        top="100%"
        right="0"
        border="1px solid #ccc"
      >
        <div class="list-notify defaultScrollbar">
          <div
            v-for="(notify, index) in listNotify.slice().reverse()"
            class="list-notify__item m-r-10 p-l-10"
            :key="index"
          >
            <div class="list-notify__title m-r-10">{{ notify.Title }}</div>
            <div class="list-notify__content">{{ notify.Content }}</div>
          </div>
          <div v-if="!listNotify.length">
            Không có thông báo
          </div>
        </div>
      </BaseContentFrame>
    </ed-icon>
  </div>
</template>
<script>
export default {
  name: "Notify",
  data() {
    return {
      showNotify: false,
      listNotify: [ 
      ]
    };
  },
  mounted() {
    // KhởI tạo hàm nhận thông báo 
    this.receiveNotify();
  },
  methods: {
    /**
     * Nhận thông báo
     * CreatedBy: NTDUNG (24/11/2021)
     */
    receiveNotify() {
      this.$SignalR.on("ReceiveNotify", (user, notify) => {
        this.listNotify.push({ User: user, Title: notify.Title, Content: notify.Content });
      });
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/layouts/notify/notify.scss";
</style>
