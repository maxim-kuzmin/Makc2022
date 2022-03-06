import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'Home',
    redirect: { name: 'Dashboard' },
  },
  {
    path: '/heroes',
    name: 'Heroes',
    component: () => import('@/views/Heroes/index.vue'),
  },
  {
    path: '/dashboard',
    name: 'Dashboard',
    component: () => import('@/views/Dashboard/index.vue'),
  },
  {
    path: '/detail/:heroId',
    name: 'Detail',
    component: () => import('@/views/HeroDetail/index.vue'),
  },
  {
    path: '/:catchAll(.*)',
    name: 'NotFound',
    component: () => import('@/views/NotFound/index.vue'),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
