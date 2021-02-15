<template>
  <div class="admin-page">
    <section class="existing-books">
      <h1>Admin</h1>
      <h2>Books</h2>
      <BookList
        :books="loadedBooks"
        isAdmin
      />
    </section>
  </div>
</template>

<script>
import BookList from '@/components/Books/BookList'

export default {
  layout: 'admin',
  components: {
    BookList
  },
  computed: {
    loadedBooks() {
      return this.$store.getters.loadedBooks;
    }
  }
}
</script>

<style scoped>
.admin-page {
  padding: 20px;
}

.new-book {
  text-align: center;
  border-bottom: 2px solid #ccc;
  padding-bottom: 10px;
}

.existing-books h2 {
  text-align: center;
}
</style>
