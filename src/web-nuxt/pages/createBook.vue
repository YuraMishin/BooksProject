<template>
  <div>
    <h1>Create book + Video</h1>

    <div v-if="books">
      <div v-for="b in books">
        {{b.id}} - {{b.title}}
      </div>
    </div>
    <hr>
    <div v-if="submissions">
      <div v-for="s in submissions">
        {{s.id}} - {{s.description}} - {{s.bookId}}
        <div>
          <video
            width="200"
            controls
            :src="`http://localhost:5000/api/videos/${s.video}`"></video>
        </div>
      </div>
    </div>


  </div>
</template>

<script>
  import {mapState} from 'vuex';

  export default {
    name: "createBook",
    layout: 'index2Layout',
    computed: {
      ...mapState('books', ['books']),
      ...mapState('submissions', ['submissions'])
    }
  }
</script>

<style scoped>

</style>
