import Vue from 'vue'
import App from './App'

// Setting: Cài đặt
import setting from '../static/setting.js'

// Plugin: Sử dụng chung
import plugin from './plugin/plugin.js'

// SignalR: Kết nối realtime
import SignalR from './signalr/signalR.js'

// Global components
import './globalComponents.js'

// Mixins
import '@/mixins'

// Store
import Store from '@/store'

// Integrated: Tích hợp
import router from './router'
import i18n from '@/i18n/i18n.js'

/* eslint-disable no-new */
const app = new Vue({
  el: '#app',
  store: Store,
  setting,
  plugin,
  SignalR,
  router,
  i18n,
  components: { App },
  template: '<App/>',
  data: {
    contentLoading: false,
  }
});

// Thêm content-loading khi chuyển routing
router.beforeEach((to, from, next) => {
  app.contentLoading = true;
  next()
});

router.afterEach(() => {
  app.contentLoading = false;
});


