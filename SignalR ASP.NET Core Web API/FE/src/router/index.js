import Vue from 'vue' 
import Router from 'vue-router'

// Router
import Main from './Main/Main.js'
import Authen from './Authen/Authen.js'

Vue.use(Router)

export default new Router({
    mode: "history",
    routes: [
        {path: '/login', component: () => import('@/views/Authen/Login/Login.vue')},
        ...Main,
        ...Authen
    ]
})