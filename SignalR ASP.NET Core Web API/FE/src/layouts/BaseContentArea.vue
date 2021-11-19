<template lang="">
    <div class="base-content-area">
        <div class="area-header">
            <slot v-slot="header"></slot>
        </div>
        <div class="area-content">
            <slot v-slot="content"></slot>  
        </div>
        <div class="area-footer">
            <slot v-slot="footer"></slot>  
        </div> 
    </div>
</template>
<script>
export default {
    name: "BaseContentArea" 
}
</script>
<style lang="scss">
    @import "@/assets/scss/layouts/basecontentarea.scss";
</style>