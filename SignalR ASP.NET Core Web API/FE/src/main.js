import Vue from 'vue'
import App from './App'

// Setting: Cài đặt
import setting from '../static/setting.js'

// Plugin: Sử dụng chung
import plugin from './plugin/plugin.js'

// Integrated: Tích hợp
import router from '@/router'
import i18n from '@/i18n/i18n.js'

/* eslint-disable no-new */
new Vue({
  el: '#app',
  setting,
  plugin,
  router,
  i18n,
  components: { App },
  template: '<App/>'
})
