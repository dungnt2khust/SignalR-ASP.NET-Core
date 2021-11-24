<template lang="">
    <div 
        :class="[
        'row fx-row',
        'row-w-' + rowW,
        'row-xs-' + rowXs,
        'row-sm-' + rowSm,
        'row-lg-' + rowLg
        ]"
    >
        <slot></slot> 
    </div>
</template>
<script>
export default {
    name: "Row", 
    props: {
        rowW: {
            type: [Number, String],
            default: 12
        },
        rowXs: {
            type: [Number, String],
            default: 0
        },
        rowSm: {
            type: [Number, String],
            default: 0
        },
        rowLg: {
            type: [Number, String],
            default: 0
        }
    }
}
</script>
<style lang="scss"> 
   @mixin setRow($name) {
       @for $row from 1 to 13 {
           $flexBasis: percentage(1 / 12 * $row);
           .#{'row-' + $name + '-' + $row} {
               flex-basis: $flexBasis !important;
           }
       }
   }
   @include setRow(w);
   @include setRow(lg); 
</style>