<template lang="">
    <div class="header">
        <div class="header__main">
            <Logo/> 
        </div>
        <nav-bar/>
    </div>
</template>
<script>
import NavBar from "@/layouts/NavBar.vue";
import Logo from "@/layouts/Logo.vue";

export default {
    name: "Header",
    components: {
        NavBar,
        Logo
    }
}
</script>
<style lang="scss">
    @import "@/assets/scss/layouts/header.scss"; 
</style>