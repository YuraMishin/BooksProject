<template>
  <div class="d-flex justify-center align-start">
    <div class="mx-2" v-if="submissions">
      <div v-for="s in submissions">
        {{s.description}} - {{s.bookId}}
        <div>
          <video width="200" controls
                 :src="`http://localhost:5000/api/videos/${s.video}`"></video>
        </div>
      </div>
    </div>

    <v-sheet class="pa-3 ma-2 sticky">
      <div class="text-h5">
        <span>{{ book.title }}</span>
        <v-chip
          class="mb-1 ml-2"
          small
          :to="`/v2/difficulty/${difficulty.id}`">
          {{ difficulty.name }} Difficulty
        </v-chip>
      </div>
      <v-divider class="my-1"></v-divider>

      <div class="text-body-2">{{ book.description }}</div>

      <v-divider class="my-1"></v-divider>

      <div v-for="rd in relatedData" v-if="rd.data.length > 0">
        <div class="text-subtitle-1">{{rd.title}}</div>
        <v-chip-group>
          <v-chip v-for="(d, index) in rd.data" :key="index" small
                  :to="rd.routeFactory(d)">
            {{d.title ? d.title : d.name}}
          </v-chip>
        </v-chip-group>
      </div>
    </v-sheet>
  </div>
</template>

<script>
  import {mapState, mapGetters} from 'vuex';

  export default {
    name: "index",
    layout: 'index2Layout',
    data: () => ({
      book: null,
      difficulty: null
    }),
    computed: {
      ...mapState('submissions', ['submissions']),
      ...mapState('books', ['categories', 'books']),
      ...mapGetters('books', ['bookById', 'difficultyById']),
      relatedData() {
        return [
          {
            title: "Categories",
            data: this.categories.filter(x => this.book.categories.indexOf(x.id) >= 0),
            idFactory: c => `category-${c.title}`,
            routeFactory: c => `/v2/category/${c.id}`,
          },
          {
            title: "Prerequisites",
            data: this.books.filter(x => this.book.prerequisites.indexOf(x.id) >= 0),
            idFactory: t => `book-${t.title}`,
            routeFactory: t => `/v2/book/${t.id}`,
          },
          {
            title: "Progressions",
            data: this.books.filter(x => this.book.progressions.indexOf(x.id) >= 0),
            idFactory: t => `book-${t.title}`,
            routeFactory: t => `/v2/book/${t.id}`,
          },
        ]
      },
    },
    async fetch() {
      const bookId = this.$route.params.book;
      this.book = this.bookById(bookId);
      this.difficulty = this.difficultyById(this.book.difficultyId)
      await this.$store.dispatch("submissions/fetchSubmissionsForBook", {bookId}, {
        root:
          true
      })
    },
    head() {
      if (!this.book) return {};

      return {
        title: this.book.title,
        meta: [
          {hid: 'description', name: 'description', content: this.book.description}
        ]
      }
    }
  }
</script>

<style scoped>

</style>
