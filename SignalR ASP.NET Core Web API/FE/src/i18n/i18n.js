/* eslint-disable*/
import Vue from 'vue'
import VueI18n from 'vue-i18n'
import i18nData from './i18nData.js'

Vue.use(VueI18n)

const i18n = new VueI18n({
    locale: 'vi', // set locale
    fallbackLocale: 'vi', // set fallback locale
    messages: i18nData, // set locale messages
});

export default i18n