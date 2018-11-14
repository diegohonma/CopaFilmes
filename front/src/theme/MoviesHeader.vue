<template>
  <div class='column is-full'>
    <div class='hero has-text-weight-bold'>
      <div class='hero-body'>
        <div class='container has-text-centered'>
          <p class='subtitle has-text-grey-light'>Campeonato de filmes</p>
          <p class='title has-text-white'><slot name='step'></slot></p>
          <p class='has-text-white'><slot name='step-desc'></slot></p>
        </div>        
      </div>
    </div>
  </div>
</template>
<style scoped lang='scss'>
  @import '~bulma';

  .hero{
    background-color: $grey
  }
  .container{
      width: 50%
  }
</style>