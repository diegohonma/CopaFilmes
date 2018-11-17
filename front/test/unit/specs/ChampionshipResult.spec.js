import ChampionshipResult from '../../../src/theme/ChampionshipResult.vue'
import Vuex from 'vuex'
import Vue from 'vue'
import { shallowMount } from '@vue/test-utils'

Vue.use(Vuex)

describe('ChampionshipResult.vue', () => {
  it('should render results from store', () => {
    let championshipModules = {
      namespaced: true,
      state: {},
      getters: {
        results: () => [
          { position: 1, title: 'Filme 1' },
          { position: 2, title: 'Filme 2' }
        ]
      }
    }

    let store = new Vuex.Store({
      modules: {
        championshipModules
      }
    })

    const wrapper = shallowMount(ChampionshipResult, {
      store
    })

    expect(wrapper.findAll('.position').length).to.equal(2)
    expect(wrapper.findAll('.movie').length).to.equal(2)
  })
})
