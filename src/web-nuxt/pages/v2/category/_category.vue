<template>
  <div class="d-flex mt-3 justify-center align-start">
    <div class="mx-2">
      <v-text-field
        label="Search"
        placeholder="e.g. space"
        v-model="filter"
        prepend-inner-icon="mdi-magnify"
        outlined>
      </v-text-field>

      <div v-for="b in filteredBooks">
        {{b.title}} - {{b.description}}
      </div>
    </div>

    <v-sheet class="pa-3 mx-2 sticky" v-if="category">
      <div class="text-h6">{{ category.name }}</div>
      <v-divider class="my-1"></v-divider>
      <div class="text-body-2">{{ category.description }}</div>
    </v-sheet>
  </div>
</template>

<script>
  import {mapGetters} from 'vuex'

  export default {
    layout: 'index2Layout',
    data: () => ({
      category: null,
      books: [],
      filter: "",
    }),
    computed: {
      ...mapGetters('books', ['categoryById']),
      filteredBooks() {
        if (!this.filter) return this.books;

        const normalize = this.filter.trim().toLowerCase();
        return this.books.filter(
          book =>
            book.title.toLowerCase().includes(normalize)
            || book.description.toLowerCase().includes(normalize));
      }
    },
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
