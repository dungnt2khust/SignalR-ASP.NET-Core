<template lang="">
  <div class="homepage">
  </div>
</template>
<script>

export default {
  name: "HomePage", 
  data() {
    return {
      products: []
    };
  },
  mounted() {
  },
  methods: {
    /**
     * Lấy dữ liệu danh sách sản phẩm
     * CreatedBy: NTDUNG (02/11/2021)
     */
    getListProduct() {
      ProductAPI.getFilterPaging("", 1, 10)
        .then(res => {
          if (res && res.data && res.data.Success) {
            this.products = res.data.Data.Records;
            this.products = this.products.map(product => {
              if (product.Image) {
                var src = "data:image/gif;base64," + product.Image;
                product.Image = {
                  src: src,
                  width: "100px",
                  height: "100px"
                };
              }
              return product;
            });
          }
        })
        .catch(res => {
          console.log(res);
        });
    }, 
    login() {
      this.$router.push('/login');
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/views/HomePage/homepage.scss";
</style>
