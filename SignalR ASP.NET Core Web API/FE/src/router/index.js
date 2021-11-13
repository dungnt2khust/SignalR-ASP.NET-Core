import Vue from 'vue'
import Router from 'vue-router'
import HomePage from '@/views/HomePage/HomePage'
import Order from '@/views/Order/Order.vue'
import Cart from '@/views/Cart/Cart.vue'
import Product from '@/views/Product/Product.vue'
import MessageSignalR from '@/views/MessageSignalR/MessageSignalR.vue'

Vue.use(Router)

export default new Router({
    mode: 'history',
    routes: [
        {path: '/', redirect: 'Home'},
        {path: '/Home', component: HomePage},
        {path: '/Order', component: Order},
        {path: '/Cart', component: Cart},
        {path: '/Product', component: Product},
        {path: '/MessageSignalR', component: MessageSignalR}
    ]
})
