<template>
  <div class="books-page">
    <BookList :books="loadedBooks"/>
  </div>
</template>

<script>
  import BookList from "@/components/Books/BookList";

  export default {
    components: {
      BookList
    },
    computed: {
      loadedBooks() {
        return this.$store.getters.loadedBooks
      }
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
