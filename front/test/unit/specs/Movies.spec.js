import 'es6-promise/auto'
import Vue from 'vue'
import Movies from '../../../src/theme/Movies.vue'
import moxios from 'moxios'
import VueRouter from 'vue-router'

describe('Movies.vue', () => {
  beforeEach(function () {
    moxios.install()
  })

  afterEach(function () {
    moxios.uninstall()
  })

  it('should load movies', done => {
    Vue.use(VueRouter)

    const router = new VueRouter({
      routes: [
        { path: '/', component: Movies }
      ]
    })

    const MoviesConstructor = Vue.extend(Movies)
    const comp = new MoviesConstructor({
      router
    }).$mount()

    moxios.wait(function () {
      let request = moxios.requests.mostRecent()
      request.respondWith({
        status: 200,
        response: [
          {
            'id': 'tt3606756',
            'title': 'Os Incríveis 2',
            'year': 2018
          },
          {
            'id': 'tt4881806',
            'title': 'Jurassic World: Reino Ameaçado',
            'year': 2018
          },
          {
            'id': 'tt5164214',
            'title': 'Oito Mulheres e um Segredo',
            'year': 2018
          }]
      }).then(function () {
        expect(comp.$el.querySelectorAll('.card-content').length).to.equal(3)
        done()
      })
    })
  })
})
