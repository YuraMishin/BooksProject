<template>
  <div class="admin-book-page">
    <section class="update-form">
      <AdminBookForm
        :book="loadedBook"
        @submit="onSubmitted"
      />
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
    async asyncData({params, $axios}) {
      const loadedBook = await $axios
        .$get(`${process.env.baseUrl}${params.bookId}`);
      return {loadedBook};
    },
    methods: {
      onSubmitted(editedBook) {
        this.$store.dispatch("editBook", editedBook)
          .then(() => {
            this.$router.push('/admin')
          });
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
