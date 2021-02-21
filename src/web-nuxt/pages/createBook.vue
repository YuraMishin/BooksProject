<template>
  <div>
    <h1>Create book + Video</h1>
    <div v-if="books">
      <div v-for="b in books">
        {{b.title}}
        <div v-if="b.video">
          <video
            width="200"
            controls
            :src="`http://localhost:5000/api/videos/${b.video}`">
          </video>
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
      ...mapState('books', ['books'])
    }
  }
</script>

<style scoped>

</style>
