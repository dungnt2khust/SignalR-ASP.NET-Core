var routes = [
  { path: "/", redirect: "home" },
  {
    path: "/home",
    name: "Home",
    exact: true,
    component: () =>
      import(/* webPackChunkName: 'Home' */ "@/views/User/HomePage/HomePage.vue"),
    meta: {
      Title: "Home"
    }
  },
  {
    path: "/order",
    name: "Order",
    exact: true,
    component: () =>
      import(/* webPackChunkName: 'Home' */ "@/views/User/Order/Order.vue"),
    meta: {
      Title: "Order"
    }
  },
  {
    path: "/cart",
    name: "Cart",
    exact: true,
    component: () =>
      import(/* webPackChunkName: 'Home' */ "@/views/User/Cart/Cart.vue"),
    meta: {
      Title: "Cart"
    }
  },
  {
    path: "/messageSignalR",
    name: "SignalR",
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
