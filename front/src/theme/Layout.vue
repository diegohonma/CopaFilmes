<template>
  <div>
    <section class="main-section section">
      <div class="container content has-background-grey">
        <router-view></router-view>
      </div>
    </section>
  </div>
</template>
<style lang="scss">
  $body-background-color: hsl(0, 0%, 71%);
  
  @import '~bulma';

  .columns{
    flex-wrap: wrap
  }
  
</style>
