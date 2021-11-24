<template lang="">
    <div class="base-content-area fx-col">
        <div class="area-header">
            <slot name="header"></slot>
        </div>
        <div class="area-content fx-wrap defaultScrollbar">
            <slot name="content"></slot>  
        </div>
        <div class="area-footer">
            <slot name="footer"></slot>  
        </div> 
    </div>
</template>
<script>
export default {
    name: "BaseContentArea" 
}
</script>
<style lang="scss">
    @import "@/assets/scss/layouts/basecontentarea/basecontentarea.scss";
</style>