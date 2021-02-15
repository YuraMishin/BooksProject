<template>
  <section class="book-list">
    <BookPreview
      v-for="(book, index) in books"
      :key="index"
      :id="book.id"
      :title="book.title"
    />
  </section>
</template>

<script>
  import BookPreview from '@/components/Books/BookPreview'

  export default {
    components: {
      BookPreview
    },
    props: {
      books: {
        type: Array,
        required: true
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
