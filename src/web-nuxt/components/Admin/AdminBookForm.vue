<template>
  <form @submit.prevent="onSave">
    <AppControlInput v-model="editedBook.title">Title</AppControlInput>
    <AppButton type="submit">Save</AppButton>
    <AppButton
      type="button"
      style="margin-left: 10px"
      btn-style="cancel"
      @click="onCancel">Cancel
    </AppButton>
  </form>
</template>

<script>
  import AppControlInput from "@/components/UI/AppControlInput";
  import AppButton from "@/components/UI/AppButton";

  export default {
    components: {
      AppControlInput,
      AppButton
    },
    props: {
      book: {
        type: Object,
        required: false
      }
    },
    data() {
      return {
        editedBook: this.book
          ? {...this.book}
          : {
            title: ""
          }
      };
    },
    methods: {
      onSave() {
        // Save the book
        console.log(this.editedBook);
      },
      onCancel() {
        // Navigate back
        this.$router.push("/admin");
      }
    }
  };
</script>
