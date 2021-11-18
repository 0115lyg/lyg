import Vue from 'vue'
import VueRouter from 'vue-router'
import AppointNav from "../views/AppointNav";
import MainView from "../components/MainView";
import Set from "../views/Set";
import AppointDoc from "../views/AppointDoc";
import InfGate from "../views/InfGate";

Vue.use(VueRouter)

const routes = [
  {
    path: '',
    redirect: '/MainView'
  },
  {
    path: '/MainView',
    name: 'MainView',
    component: MainView,
    redirect: '/InfGate',
    meta: {
      requireAuth: true
    },
    children: [
      {
        path: '/InfGate',
        name: 'InfGate',
        component: InfGate
      },
      {
        path: '/AppointNav',
        name: 'AppointNav',
        component: AppointNav
      },
      {
        path: '/Set',
        name: 'Set',
        component: Set
      },
      {
        path: '/AppointDoc',
        name: 'AppointDoc',
        component: AppointDoc
      },
    ]
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
