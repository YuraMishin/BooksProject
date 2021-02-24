<template>
  <div>
    <h1>Books</h1>
    <div v-if="books">
      <div
        style="margin: 10px"
        v-for="b in books"
      >
        <v-btn :to="`/v2/books/${b.id}`">{{b.title}}</v-btn>
      </div>
    </div>
  </div>
</template>

<script>
  import {mapState} from 'vuex';

  export default {
    name: "index",
    layout: 'index2Layout',
    computed: {
      ...mapState('books', ['books'])
    },
    async fetch() {
      await this.$store.dispatch("books/fetchBooks", null, {root: true});
    }
  }
</script>

<style scoped>

</style>
