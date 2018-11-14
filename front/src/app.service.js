import axios from 'axios'

axios.defaults.baseURL = 'http://localhost:5000/api'

const appService = {
  getMovies () {
    return new Promise((resolve) => {
      axios.get('/movies')
        .then(response => {
          resolve(response.data)
        })
    })
  },
  getChampionshipResults (movies) {
    return new Promise((resolve, reject) => {
      axios.post('/championships', movies)
        .then(response => {
          resolve(response.data)
        }).catch(response => {
          reject(response.status)
        })
    })
  }
}

export default appService
