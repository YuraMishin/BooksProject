<template>
  <div>
    Create book 2
    <v-container>
      <v-row>
        <v-col>
          <v-text-field label="Book Name" v-model="bookName"/>
          <v-btn @click="saveBook">Create</v-btn>
        </v-col>
        <v-col></v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
  import {mapActions} from 'vuex'
  export default {
    name: "CreateBook2",
    data: () => ({
      bookName: ""
    }),
    methods: {
      ...mapActions('books', ['addBook']),
      async saveBook() {
        await this.addBook({book: {title: this.bookName}});
        this.bookName = '';
        this.$router.push('/admin')
      }
    }
  }
</script>

<style scoped>

</style>
