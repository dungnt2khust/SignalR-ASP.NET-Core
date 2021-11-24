const routes = [
    {
        path: '/login',
        name: "Login",
        component: () => import ("@/views/Authen/Login/Login.vue"),
        meta: {
            Title: "i18nMenu.Authen.Login"
        }
    },
    {
        path: '/register',
        name: "Register",
        component: () => import ("@/views/Authen/Register/Register.vue"),
        meta: {
            Title: "i18nMenu.Authen.Register"
        }
    },
    {
        path: '/no-permission',
        name: "NoPermision",
        component: () => import ("@/views/Authen/NoPermission/NoPermission.vue"),
        meta: {
            Title: "i18nMenu.Authen.NoPermission"
        }
    },
    {
        path: '/not-found',
        name: "NotFound",
        component: () => import ("@/views/Authen/NotFound/NotFound.vue"),
        meta: {
            Title: "i18nMenu.Authen.NotFound"
        }
    }
];

export default routes;
