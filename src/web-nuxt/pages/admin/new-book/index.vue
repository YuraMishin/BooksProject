<template>
  <div class="admin-new-book-page">
    <section class="new-book-form">
      <AdminBookForm @submit="onSubmitted"/>
    </section>
  </div>
</template>

<script>
  import AdminBookForm from "@/components/Admin/AdminBookForm";

  export default {
    layout: 'admin',
    components: {
      AdminBookForm
    },
    methods: {
      onSubmitted(postData) {
        this.$axios
          .post('http://localhost:5000/api/books/', postData)
          .then(result => this.$router.push('/admin'))
          .catch(e => console.log(e))
      }
    }
  };
</script>

<style scoped>
  .new-book-form {
    width: 90%;
    margin: 20px auto;
  }

  @media (min-width: 768px) {
    .new-book-form {
      width: 500px;
    }
  }
</style>
