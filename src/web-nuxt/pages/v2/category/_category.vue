<template>
  <div class="d-flex mt-3 justify-center align-start">
    <book-list :books="books" class="mx-2"/>

    <v-sheet class="pa-3 mx-2 sticky" v-if="category">
      <div class="text-h6">{{ category.name }}</div>
      <v-divider class="my-1"></v-divider>
      <div class="text-body-2">{{ category.description }}</div>
    </v-sheet>
  </div>
</template>

<script>
  import {mapGetters} from 'vuex';
  import BookList from "../../../components/book-list-v2";

  export default {
    layout: 'index2Layout',
    components: {BookList},
    data: () => ({
      category: null,
      books: []
    }),
    computed: mapGetters('books', ['categoryById']),
    async fetch() {
      const categoryId = this.$route.params.category;
      this.category = this.categoryById(categoryId);
      this.books = await this.$axios.$get(`categories/${categoryId}/books/`);
    },
    head() {
      if (!this.category) return {}

      return {
        title: this.category.name,
        meta: [
          {hid: 'description', name: 'description', content: this.category.description}
        ]
      }
    }
  }
</script>

<style scoped>

</style>
