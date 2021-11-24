import Vue from 'vue'

import FlagIcon from 'vue-flag-icon'
import EventBus from '@/bus/eventbusGlobal.js'
import Popup from '@/common/popup.js'
import Tooltip from '@/common/Tooltip.js'
import Notify from '@/common/Notify.js'

// Account Auth
import AccountAPI from '@/api/components/Account/AccountAPI.js'

Vue.use(FlagIcon);

Vue.prototype.$bus = EventBus;
Vue.prototype.$popup = Popup;
Vue.prototype.$tooltip = Tooltip;
Vue.prototype.$notify = Notify;
Vue.prototype.$account = AccountAPI;

export default Vue;