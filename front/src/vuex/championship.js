import appService from '../app.service.js'

const state = {
  results: []
}

const getters = {
  results: state => state.results
}

const actions = {
  getChampionshipResults (context, movies) {
    appService.getChampionshipResults(movies.map((movieId) => {
      return {
        id: movieId
      }
    })).then(data => {
      context.commit('getChampionshipResults', data.classification)
    })
  }
}

const mutations = {
  getChampionshipResults (state, classification) {
    state.results = classification.map((classificationPosition) => {
      return {
        position: classificationPosition.position,
        title: classificationPosition.movie.title
      }
    })
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
