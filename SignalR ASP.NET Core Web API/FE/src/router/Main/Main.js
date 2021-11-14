const routes = [
    {path: "/", redirect: 'home'},
    { 
        path: '/home',
        name: 'Home',
        component: () => import ('@/views/HomePage/HomePage.vue'),
        meta: {
            Title: "i18nMenu.Main.Home"
        }
    },
    { 
        path: '/order',
        name: 'Order',
        component: () => import ("@/views/Order/Order.vue"),
        meta: {
            Title: "i18nMenu.Main.Order"
        }
    },
    { 
        path: '/cart',
        name: 'Cart',
        component: () => import ('@/views/Cart/Cart.vue'),
        meta: {
            Title: "i18nMenu.Main.Cart"
        }
    },
    { 
        path: '/messageSignalR',
        name: 'SignalR',
        component: () => import ('@/views/MessageSignalR/MessageSignalR.vue'),
        meta: {
            Title: "i18nMenu.Main.MessageSignalR"
        }
    },
    { 
        path: '/admin',
        name: 'Admin',
        component: () => import ('@/views/Admin/Admin.vue'),
        meta: {
            Title: "i18nMenu.Main.Admin"
        }
    }
];
export default routes;