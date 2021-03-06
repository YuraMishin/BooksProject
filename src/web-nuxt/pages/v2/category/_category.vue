<template>
  <item-content-layout>
    <template v-slot:content>
      <book-list :books="books"/>
    </template>
    <template v-slot:item>
      <div v-if="category">
        <div class="text-h6">{{ category.name }}</div>
        <v-divider class="my-1"></v-divider>
        <div class="text-body-2">{{ category.description }}</div>
      </div>
    </template>
  </item-content-layout>

</template>

<script>
  import {mapGetters} from 'vuex';
  import BookList from "../../../components/book-list-v2";
  import ItemContentLayout from "../../../components/v2/item-content-layout";

  export default {
    layout: 'index2Layout',
    components: {
      BookList,
      ItemContentLayout
    },
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
