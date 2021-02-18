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
        v-if="books"
        :books="books"
        isAdmin
      />
    </section>
  </div>
</template>

<script>
  import {mapState} from 'vuex';

  export default {
    layout: 'admin',
    computed: {
      ...mapState('books', {
        books: state => state.books
      })
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
