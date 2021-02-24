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

    <div class="mx-2 sticky">
      Book: {{ $route.params.book }}
    </div>
  </div>
</template>

<script>
  import {mapState} from 'vuex';

  export default {
    name: "index",
    layout: 'index2Layout',
    computed: mapState('submissions', ['submissions']),
    async fetch() {
      const bookId = this.$route.params.book;
      await this.$store.dispatch("submissions/fetchSubmissionsForBook", {bookId}, {
        root:
          true
      })
    }
  }
</script>

<style scoped>
  .sticky {
    position: -webkit-sticky;
    position: sticky;
    top: 48px;
  }
</style>
