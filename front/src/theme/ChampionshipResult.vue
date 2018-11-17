<template>
<div>
  <div class='columns'>
    <movies-header>
      <span slot='step'>Resultado Final</span>
      <span slot='step-desc'>Veja o resultado final do Campeonato de filmes de forma simples e rápida</span>
    </movies-header>
    <div class="column is-full">
      <div class='container is-fluid'>
        <div class='columns results' v-for='result in results' v-bind:key='result.position'>
          <div class='column is-1 position'>
            <p>{{result.position}}º</p>
          </div>
          <div class='column is-11 is-vcentered movie'>
            <p>{{result.title}}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
</template>
<script>
  import MoviesHeader from './MoviesHeader.vue'
  import { mapGetters } from 'vuex'
  export default {
    components: {
      'movies-header': MoviesHeader
    },
    computed: {
      ...mapGetters('championshipModules', ['results'])
    }
  }
</script>
<style scoped lang='scss'>
  @import '~bulma';
  .position{
    background-color: $grey;
    color: white;
    font-size: 30px;
    width: 60px!important;
    text-align: center;
    display: flex;
    align-items: center;
  }
  .movie {
    background-color: $white-ter;
    display: flex;
    align-items: center;
  }
  .results {
    margin-bottom: 30px!important;
  }
</style>