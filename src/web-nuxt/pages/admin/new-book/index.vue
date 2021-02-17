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
        this.$store.dispatch("addBook", postData)
        .then(()=>{
          this.$router.push('/admin')
        });
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
