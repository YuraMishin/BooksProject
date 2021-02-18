<template>
  <div class="admin-new-book-page">
    <section class="new-book-form">
      <AdminBookForm @submit="onSubmitted"/>
    </section>
    <section>
      <CreateBook2/>
    </section>
  </div>
</template>

<script>
  import AdminBookForm from "@/components/Admin/AdminBookForm";
  import CreateBook2 from "../../../components/Admin/CreateBook2";

  export default {
    layout: 'admin',
    components: {
      CreateBook2,
      AdminBookForm
    },
    methods: {
      onSubmitted(postData) {
        this.$store.dispatch("books/addBook2", postData)
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
