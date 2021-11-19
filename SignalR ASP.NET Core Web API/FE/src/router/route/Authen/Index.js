const routes = [
    {
        path: '/login',
        name: "Login",
        component: () => import ( /* webPackChunkName: 'Home' */ "@/views/Authen/Login/Login.vue"),
        meta: {
            Title: "Login"
        }
    },
    {
        path: '/register',
        name: "Register",
        component: () => import ( /* webPackChunkName: 'Home' */ "@/views/Authen/Register/Register.vue"),
        meta: {
            Title: "Register"
        }
    },
    {
        path: '/no-permission',
        name: "NoPermision",
        component: () => import ( /* webPackChunkName: 'Home' */ "@/views/Authen/NoPermission/NoPermission.vue"),
        meta: {
            Title: "NoPermission"
        }
    },
    {
        path: '/not-found',
        name: "NotFound",
        component: () => import ( /* webPackChunkName: 'Home' */ "@/views/Authen/NotFound/NotFound.vue"),
        meta: {
            Title: "NotFound"
        }
    }
];

export default routes;
