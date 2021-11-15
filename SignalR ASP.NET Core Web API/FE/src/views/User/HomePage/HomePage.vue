<template lang="">
  <div class="homepage">
    <base-grid-product 
      :title="$t('i18nProduct.Type.Hot')"
      type="hot"
      :products="products" />
  </div>
</template>
<script>
import ProductAPI from "@/api/components/Product/ProductAPI.js";
import BaseGridProduct from "@/components/BaseGridProduct/BaseGridProduct.vue";

export default {
  name: "HomePage",
  components: {
    BaseGridProduct
  },
  data() {
    return {
      products: []
    };
  },
  mounted() {
    this.getListProduct();
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
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/views/HomePage/homepage.scss";
</style>
