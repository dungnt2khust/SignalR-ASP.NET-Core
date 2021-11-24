var routes = [
  { path: "/", redirect: "/admin/dashboard" },
  {
    path: "/admin/dashboard",
    name: "AdminDashboard",
    exact: true,
    component: () => import("@/views/Admin/Dashboard/Dashboard.vue"),
    meta: {
      Title: "i18nMenu.Admin.Dashboard"
    }
  },
  {
    path: "/admin/order",
    name: "AdminOrder",
    exact: true,
    component: () => import("@/views/Admin/Order/Order.vue"),
    meta: {
      Title: "i18nMenu.Order"
    }
  },
  {
    path: "/admin/product",
    name: "AdminProduct",
    exact: true,
    component: () => import("@/views/Admin/Product/Product.vue"),
    meta: {
      Title: "i18nMenu.Product"
    }
  },
  {
    path: "/admin/push-notify",
    name: "AdminPushNotify",
    exact: true,
    component: () => import("@/views/Admin/PushNotify/PushNotify.vue"),
    meta: {
      Title: "i18nMenu.Admin.PushNotify"
    }
  } 
]
export default routes
