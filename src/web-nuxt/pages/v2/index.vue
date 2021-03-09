<template>
  <div>
    <h1>Books</h1>
    <div>
      <div v-for="(s, index) in sections" :key="index">
        <div class="d-flex flex-column align-center">
          <p class="text-h5">
            {{s.title}}
          </p>
          <div>
            <v-btn
              class="mx-1"
              v-for="(item, index) in s.collection"
              :key="index"
              :to="s.routeFactory(item.id)">
              {{item.title ? item.title : item.name}}
            </v-btn>
          </div>
        </div>
        <v-divider class="my-5"></v-divider>
      </div>
    </div>
  </div>
</template>

<script>
  import {mapState} from 'vuex';

  export default {
    name: "index",
    layout: 'index2Layout',
    computed: {
      ...mapState('books', [
        'books',
        'categories',
        'difficulties'
      ]),
      sections() {
        return [
          {
            collection: this.books,
            title: "Books",
            routeFactory: (id) => `/v2/book/${id}`
          },
          {
            collection: this.categories,
            title: "Categories",
            routeFactory: (id) => `/v2/category/${id}`
          },
          {
            collection: this.difficulties,
            title: "Difficulties",
            routeFactory: (id) => `/v2/difficulty/${id}`
          },
        ]
      }
    }
  }
</script>

<style scoped>

</style>
