<template lang="">
    <div 
        :class="[
        'col',
        'col-w-' + colW,
        'col-xs-' + colXs,
        'col-sm-' + colSm,
        'col-lg-' + colLg
        ]"
    >
        <slot></slot>
    </div>
</template>
<script>
export default {
    name: "Col", 
    props: {
        colW: {
            type: [Number, String],
            default: 12
        },
        colXs: {
            type: [Number, String],
            default: 0
        },
        colSm: {
            type: [Number, String],
            default: 0
        },
        colLg: {
            type: [Number, String],
            default: 0
        }
    }
}
</script>
<style lang="scss"> 
   @mixin setCol($name) {
       @for $col from 1 to 13 {
           $flexBasis: percentage(1 / 12 * $col);
           .#{'col-' + $name + '-' + $col} {
               flex-basis: $flexBasis !important;
           }
       }
   }
   @include setCol(w);
   @include setCol(lg);
   
   @media only screen and (max-width: 780px){
       @include setCol(xs);
   }
</style>