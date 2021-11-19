var routes = [
  { path: "/", redirect: "/admin/home" },
  {
    path: "/admin/home",
    name: "AdminHome",
    exact: true,
    component: () =>
      import(/* webPackChunkName: 'Home' */ "@/views/User/HomePage/HomePage.vue"),
    meta: {
      Title: "Home"
    }
  },
  {
    path: "/admin/order",
    name: "AdminOrder",
    exact: true,
    component: () =>
      import(/* webPackChunkName: 'Home' */ "@/views/User/Order/Order.vue"),
    meta: {
      Title: "Order"
    }
  },
  {
    path: "/admin/cart",
    name: "AdminCart",
    exact: true,
    component: () =>
      import(/* webPackChunkName: 'Home' */ "@/views/User/Cart/Cart.vue"),
    meta: {
      Title: "Cart"
    }
  },
  {
    path: "/admin/messageSignalR",
    name: "admin/SignalR",
    exact: true,
    component: () =>
      import(
        /* webPackChunkName: 'Home' */ "@/views/User/MessageSignalR/MessageSignalR.vue"
      ),
    meta: {
      Title: "MessageSignalR"
    }
  } 
]
export default routes
