const routes = [
    {
        path: 'login',
        name: "Login",
        component: () => import ( /* webPackChunkName: 'Home' */ "@/views/Authen/Login/Login.vue"),
        meta: {
            Title: "Login"
        }
    },
];

export default routes;
