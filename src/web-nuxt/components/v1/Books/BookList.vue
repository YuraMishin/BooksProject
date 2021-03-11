<template>
  <section class="book-list">
    <BookPreview
      v-for="(book, index) in books"
      :key="index"
      :id="book.id"
      :title="book.title"
      :is-admin="isAdmin"
    />
  </section>
</template>

<script>
  import BookPreview from '@/components/v1/Books/BookPreview'

  export default {
    components: {
      BookPreview
    },
    props: {
      books: {
        type: Array,
        required: true
      },
      isAdmin: {
        type: Boolean,
        required: false
      }
    }
  }
</script>

<style scoped>

  .book-list {
    display: flex;
    padding: 20px;
    box-sizing: border-box;
    flex-wrap: wrap;
    align-items: center;
    justify-content: center;
  }
</style>
