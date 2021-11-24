import Vue from 'vue'
import commonFunction from '@/mixins/commonFunction.js'
import commonFunction2 from '@/mixins/commonFunction2.js'
import storage from '@/mixins/storage.js'

Vue.mixin(commonFunction);
Vue.mixin(commonFunction2);
Vue.mixin(storage);
export default Vue;