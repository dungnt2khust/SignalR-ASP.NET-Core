import Vue from 'vue'
import Vuex from 'vuex'
import Account from '@/models/model/Account/Account.js'
import Guest from '@/router/menu/Guest'

Vue.use(Vuex)

const store = new Vuex.Store({
  state: {
      accountData: {
        AccountType: 0,
        Data: Account.initData()
      },
      navBar: Guest
  },
  mutations: {
    setAccountData (accountData) {
        state.accountData = accountData;
    }
  }
});

export default store;