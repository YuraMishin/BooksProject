<template>
  <div>
    <v-text-field
      label="Search"
      placeholder="e.g. space"
      v-model="filter"
      prepend-inner-icon="mdi-magnify"
      outlined>
    </v-text-field>
    <div v-for="book in filteredBooks">
      {{book.title}} - {{book.description}}
    </div>
  </div>
</template>

<script>
  export default {
    name: "book-list-v2",
    props: {
      books: {
        required: true,
        type: Array
      }
    },
    data: () => ({
      filter: ""
    }),
    computed: {
      filteredBooks() {
        if (!this.filter) return this.books;

        const normalize = this.filter.trim().toLowerCase();
        return this.books.filter(t => t.title.toLowerCase().includes(normalize)
          || t.description.toLowerCase().includes(normalize))
      }
    }
  }
</script>

<style scoped>

</style>
