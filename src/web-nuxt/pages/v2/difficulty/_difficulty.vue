<template>
  <item-content-layout>
    <template v-slot:content>
      <book-list :books="books"/>
    </template>
    <template v-slot:item>
      <div v-if="difficulty">
        <div class="text-h6">{{ difficulty.name }}</div>
        <v-divider class="my-1"></v-divider>
        <div class="text-body-2">{{ difficulty.description }}</div>
      </div>
    </template>
  </item-content-layout>

</template>

<script>
  import {mapGetters} from 'vuex'
  import BookList from "../../../components/book-list-v2";
  import ItemContentLayout from "../../../components/v2/item-content-layout";

  export default {
    layout: 'index2Layout',
    components: {
      BookList,
      ItemContentLayout
    },
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
