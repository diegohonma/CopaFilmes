import Vue from 'vue'
import VueRouter from 'vue-router'
import Movies from './theme/Movies.vue'
import ChampionshipResult from './theme/ChampionshipResult.vue'

Vue.use(VueRouter)

const router = new VueRouter({
  mode: 'history',
  linkActiveClass: 'is-active',
  scrollBehavior: (to, from, savedPosition) => ({ y: 0 }),
  routes: [
    { path: '/movies', component: Movies },
    { path: '/championship/results', props: true, component: ChampionshipResult },
    { path: '*', redirect: '/movies' }
  ]
})

export default router
