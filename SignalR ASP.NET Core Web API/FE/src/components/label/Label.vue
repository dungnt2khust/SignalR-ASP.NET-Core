<template lang="">
    <div class="label">
        <span>{{value}}</span> 
    </div>
</template>
<script>
export default {
   name: "Label",
   props: {
       value: {
           type: String,
           default: ""
       },
       required: {
           type: Boolean,
           default: false
       }
   }
}
</script>
<style lang="scss">
    @import "@/assets/scss/components/label/label.scss" ;
</style>