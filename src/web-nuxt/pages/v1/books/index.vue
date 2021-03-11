<template>
  <div class="books-page">
    <BookList v-if="books"
              :books="books"/>
  </div>
</template>

<script>
  import {mapState} from 'vuex';

  export default {
    layout: 'v1/default',
    computed: {
      ...mapState('books', {
        books: state => state.books
      })
    },
    head: {
      title: 'Books'
    }
  };
</script>

<style scoped>
  .books-page {
    display: flex;
    justify-content: center;
    align-items: center;
  }
</style>
