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
  import {v4 as uuid} from 'uuid';

  export default {
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
            id: uuid(),
            title: ""
          }
      };
    },
    methods: {
      onSave() {
        // Save the book
        this.$emit('submit', this.editedBook);
      },
      onCancel() {
        // Navigate back
        this.$router.push("/v1/admin");
      }
    }
  };
</script>
