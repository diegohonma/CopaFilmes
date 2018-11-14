<template>
<div>
  <div class='columns'>
    <movies-header>
      <span slot='step'>Resultado Final</span>
      <span slot='step-desc'>Veja o resultado final do Campeonato de filmes de forma simples e rápida</span>
    </movies-header>
    <div class="column is-full">
      <div class='container is-fluid'>
        <div class='columns is-vcentered' v-for='result in results' v-bind:key='result.position'>
          <div class='column is-1 position'>
            <p>{{result.position}}</p>
          </div>
          <div class='column is-11 movie'>
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

  .position, .movie{
    margin-bottom: 10px;
  }
  .position{
    background-color: $grey
  }
  .movie{
    background-color: $white-ter
  }
</style>