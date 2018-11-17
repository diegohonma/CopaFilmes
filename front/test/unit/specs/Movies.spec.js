import 'es6-promise/auto'
import Vue from 'vue'
import Movies from '../../../src/theme/Movies.vue'
import moxios from 'moxios'
import VueRouter from 'vue-router'
import { mount } from '@vue/test-utils'

Vue.use(VueRouter)

describe('Movies.vue', () => {
  beforeEach(function () {
    moxios.install()
  })

  afterEach(function () {
    moxios.uninstall()
  })

  const movies = [
    { 'id': 'tt3606756', 'title': 'Os Incríveis 2', 'year': 2018 },
    { 'id': 'tt4881806', 'title': 'Jurassic World: Reino Ameaçado', 'year': 2018 },
    { 'id': 'tt5164214', 'title': 'Oito Mulheres e um Segredo', 'year': 2018 },
    { 'id': 'tt7784604', 'title': 'Hereditário', 'year': 2018 },
    { 'id': 'tt4154756', 'title': 'Vingadores: Guerra Infinita', 'year': 2018 },
    { 'id': 'tt5463162', 'title': 'Deadpool 2', 'year': 2018 },
    { 'id': 'tt3778644', 'title': 'Han Solo: Uma História Star Wars', 'year': 2018 },
    { 'id': 'tt3501632', 'title': 'Thor: Ragnarok', 'year': 2017 },
    { 'id': 'tt2854926', 'title': 'Te Peguei!', 'year': 2018 },
    { 'id': 'tt0317705', 'title': 'Os Incríveis', 'year': 2004 },
    { 'id': 'tt3799232', 'title': 'A Barraca do Beijo', 'year': 2018 },
    { 'id': 'tt1365519', 'title': 'Tomb Raider: A Origem', 'year': 2018 },
    { 'id': 'tt1825683', 'title': 'Pantera Negra', 'year': 2018 },
    { 'id': 'tt5834262', 'title': 'Hotel Artemis', 'year': 2018 },
    { 'id': 'tt7690670', 'title': 'Superfly', 'year': 2018 },
    { 'id': 'tt6499752', 'title': 'Upgrade', 'year': 2018 }
  ]

  const createComponent = () => {
    const router = new VueRouter()
    const wrapper = mount(Movies, { router })
    return wrapper
  }

  it('should load movies', done => {
    const comp = createComponent()

    moxios.wait(function () {
      let request = moxios.requests.mostRecent()
      request.respondWith({
        status: 200,
        response: movies
      }).then(function () {
        expect(comp.findAll('.card-content').length).to.equal(16)
        done()
      })
    })
  })

  it('should enable button Gerar Meu Campeonato', done => {
    const comp = createComponent()

    moxios.wait(function () {
      let request = moxios.requests.mostRecent()
      request.respondWith({
        status: 200,
        response: movies
      }).then(function () {
        expect(comp.find('button').attributes('disabled')).to.equal('disabled')
        comp.setData({ selectedMovies: movies.slice(0, 8) })
        expect(comp.find('button').attributes('disabled')).to.equal(undefined)
        done()
      })
    })
  })
})
