<template>
  <div class="admin-page">
    <section class="new-book">
      <AppButton @click="$router.push('/admin/new-book')">
        Create Book
      </AppButton>
    </section>
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
import AppButton from "../../components/UI/AppButton";

export default {
  layout: 'admin',
  components: {
    BookList,
    AppButton
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
