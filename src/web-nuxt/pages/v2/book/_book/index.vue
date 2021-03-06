<template>
  <item-content-layout>
    <template v-slot:content>
      <div v-if="submissions">
        <div v-for="(x, index) in 10">
          <v-card class="mb-3" v-for="s in submissions" :key="index">
            <video-player :video="s.video" :key="index"/>
            <v-card-text>{{s.description}}</v-card-text>
          </v-card>
        </div>
      </div>
    </template>
    <template v-slot:item>
      <div class="text-h5">
        <span>{{ book.title }}</span>
        <v-chip class="mb-1 ml-2" small :to="`/difficulty/${difficulty.id}`">
          {{ difficulty.name }}
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
    </template>
  </item-content-layout>
</template>

<script>
  import {mapState, mapGetters} from 'vuex';
  import VideoPlayer from "../../../../components/v2/video-player";
  import ItemContentLayout from "../../../../components/v2/item-content-layout";

  export default {
    name: "index",
    layout: 'index2Layout',
    components: {
      VideoPlayer,
      ItemContentLayout
    },
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
