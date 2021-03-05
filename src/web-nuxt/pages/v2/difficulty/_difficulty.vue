<template>
  <div class="d-flex mt-3 justify-center align-start">
    <book-list :books="books" class="mx-2" />

    <v-sheet class="pa-3 mx-2 sticky" v-if="difficulty">
      <div class="text-h6">{{ difficulty.name }}</div>
      <v-divider class="my-1"></v-divider>
      <div class="text-body-2">{{ difficulty.description }}</div>
    </v-sheet>
  </div>
</template>

<script>
  import {mapGetters} from 'vuex'
  import BookList from "../../../components/book-list-v2";

  export default {
    layout: 'index2Layout',
    components: {BookList},
    data: () => ({
      difficulty: null,
      books: [],
    }),
    computed: mapGetters('books', ['difficultyById']),
    async fetch() {
      const difficultyId = this.$route.params.difficulty;
      this.difficulty = this.difficultyById(difficultyId)
      this.books = await this.$axios.$get(`difficulties/${difficultyId}/books/`)
    },
    head() {
      if (!this.difficulty) return {}

      return {
        title: this.difficulty.name,
        meta: [
          {hid: 'description', name: 'description', content: this.difficulty.description}
        ]
      }
    }
  }
</script>

<style scoped>

</style>
