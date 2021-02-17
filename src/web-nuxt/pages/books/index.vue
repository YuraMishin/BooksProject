<template>
  <div class="books-page">
    <BookList :books="loadedBooks"/>
  </div>
</template>

<script>
  export default {
    computed: {
      loadedBooks() {
        return this.$store.getters.loadedBooks
      }
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
