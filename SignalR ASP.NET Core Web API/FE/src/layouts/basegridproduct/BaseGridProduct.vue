<template lang="">
  <div class="gridproduct-wrapper" :class="type ? 'gridproduct--' + type : ''">
    <!-- Grid header -->
    <div v-if="title" class="gridproduct__header">
      <div @click="gridProductState = !gridProductState" class="gridproduct__title fx-s-between">
        <div class="mi-20">
          <i class="fas fa-sort-down transition-0.2" :class="{'rotate--90': !gridProductState}"></i>
        </div>
        {{ title }}
      </div>
      <div class="gridproduct__more fx-s-between">
        {{$t("i18nProduct.Feature.WatchAll")}}
        <div class="mi-30 m-l-5">
          <i class="fas fa-chevron-right"></i>
        </div>
      </div>
    </div>
    <div v-show="gridProductState" class="gridproduct  transition-0.4">
      <div v-for="(product, index) in products" class="gridproduct__item">
        <!-- Thẻ thông tin sản phẩm -->
        <div class="product__card">
          <!-- Ảnh sản phẩm -->
          <div
            v-if="product.Image"
            class="product-item__img"
            :style="{ 'background-image': `url(${product.Image.src})` }"
          >
            <!-- Yêu thích -->
            <div v-if="product.Hot" class="product-item__favourite">
              <i class="fas fa-check"></i>
              <span> Yêu thích</span>
            </div>
            <!-- Giảm giá -->
            <div v-if="product.ShowDiscount" class="product-item__discount">
              <span class="product-item__discount-percent"
                >{{ product.Discount }}%</span
              >
              <span class="product-item__discount-label"> GIẢM</span>
            </div>
          </div>
          <!-- Tên sản phẩm -->
          <h4 class="product-item__name">
            {{ product.ProductName }}
          </h4>
          <!-- Gía sản phẩm -->
          <div class="product-item__price">
            <span v-if="product.ShowDiscount" class="product-item__price-old">
              {{ product.OldPrice }}</span
            >
            <span class="product-item__price-current"
              >{{ product.Price }}đ
            </span>
          </div>
          <!-- Thông tin -->
          <div class="product-item__action">
            <!-- Like -->
            <span class="product-item__like">
              <i
                v-if="product.Like"
                class="product-item__liked fas fa-heart"
              ></i>
              <i
                v-if="!product.Like"
                class="product-item__unliked far fa-heart"
              ></i>
            </span>
            <!-- Đánh giá -->
            <div class="product-item__rating">
              <i
                v-for="starFull in product.Star"
                class="product-item__star--gold fas fa-star"
                :key="starFull"
              ></i>
              <i v-for="starEmpty in 5" class="fas fa-star"></i>
            </div>
            <!-- Đã bán -->
            <span class="product-item__sold"
              >{{ $t("i18nProduct.Sold", { Quantity: product.Sold }) }}
            </span>
          </div>
          <!-- Nguồn gốc -->
          <div class="product-item__origin">
            <!-- Nhãn hàng -->
            <span class="product-item__brand">{{ product.Brand }}</span>
            <!-- Đất nước -->
            <span class="product-item__country">{{ product.Country }}</span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "BaseGridProduct",
  props: {
    products: {
      type: Array,
      default: function() {
        return [];
      }
    },
    type: {
      type: String,
      default: null
    },
    title: {
      type: String,
      default: ""
    }
  },
  data() {
    return {
      gridProductState: true
    };
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/layouts/basegridproduct/basegridproduct.scss";
</style>
