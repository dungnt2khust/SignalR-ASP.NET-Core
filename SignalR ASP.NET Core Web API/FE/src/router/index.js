import Vue from 'vue' 
import Router from 'vue-router'

// Router
import User from './Route/User'
import Admin from './Route/Admin'
import Authen from './Route/Authen'

Vue.use(Router)

export default new Router({
    mode: "history",
    routes: [
        ...Authen,
        ...User,
        ...Admin
    ]
})