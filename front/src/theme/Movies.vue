<template>
<div>
  <div class='columns'>
    <movies-header>
      <span slot='step'>Fase de seleção</span>
      <span slot='step-desc'>Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir.</span>
    </movies-header>
    <div class='column is-full'>
      <div class='level'>
        <div class='level-left'>
          <div class='level-item has-text-white has-text-weight-bold'>
            <p>Selecionados {{ selectedMovies.length }} de 8 filmes</p>
          </div>
        </div>
        <div class='level-right'>
          <div class='level-item'>
            <router-link :to="{ path: 'championship/results' }">
              <button class='button is-dark'
                :disabled='selectedMovies.length < 8'
                v-on:click='getChampionshipResults()'>GERAR MEU CAMPEONATO</button>
            </router-link>
          </div>
        </div>
      </div>
    </div>
    <div class='column is-one-quarter'
      v-for='movie in movies' v-bind:key='movie.id'>
      <div class='card'>
        <div class='card-content'>
          <div class='columns is-gapless'>
            <div class='column is-one-quarter'>
              <label class='checkbox'>
                <input type='checkbox'
                  :id='movie.id'
                  :value='movie.id' v-model='selectedMovies'
                  :disabled='selectedMovies.length >= 8 && selectedMovies.indexOf(movie.id) === -1'/>
              </label>
            </div>
            <div class='column'>
              <p class='has-text-weight-bold'>{{movie.title}}</p>
              <p >{{movie.year}}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
</template>
<script>
  import MoviesHeader from './MoviesHeader.vue'
  import appService from '../app.service.js'
  
  export default {
    components: {
      'movies-header': MoviesHeader
    },
    data () {
      return {
        movies: [],
        selectedMovies: []
      }
    },
    methods: {
      getChampionshipResults () {
        this.$store.dispatch('championshipModules/getChampionshipResults', this.selectedMovies)
      },
      selectMovie (movie) {
        this.selectedMovies.push(movie)
      }
    },
    mounted () {
      appService.getMovies().then(data => {
        this.movies = data
      })
    }
  }
</script>
<style scoped>
  .card{
    padding-bottom: 30px;
    height:80%;
  }
  input[type='checkbox'] {
    width:20px;
    height:20px;
  }
</style>