<template>
  <div class="admin-book-page">
    <section class="update-form">
      <AdminBookForm :book="loadedBook"/>
    </section>
  </div>
</template>

<script>
  import AdminBookForm from '@/components/Admin/AdminBookForm'

  export default {
    layout: 'admin',
    components: {
      AdminBookForm
    },
    data() {
      return {
        loadedBook: {
          title: 'Book'
        }
      }
    }
  }
</script>

<style scoped>
  .update-form {
    width: 90%;
    margin: 20px auto;
  }

  @media (min-width: 768px) {
    .update-form {
      width: 500px;
    }
  }
</style>
