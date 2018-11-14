import Vue from 'vue'
import Vuex from 'vuex'
import championshipModules from './championship'

Vue.use(Vuex)

const store = new Vuex.Store({
  modules: {
    championshipModules
  }
})

export default store
