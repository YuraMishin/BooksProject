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

    <v-stepper v-model="step">
      <v-stepper-header>
        <v-stepper-step :complete="step > 1" step="1">Upload Video</v-stepper-step>
        <v-divider></v-divider>
        <v-stepper-step :complete="step > 2" step="2">Book Information</v-stepper-step>
        <v-divider></v-divider>
        <v-stepper-step :complete="step === 3" step="3">Confirmation</v-stepper-step>
      </v-stepper-header>
      <v-stepper-items>
        <v-stepper-content step="1">
          <div>
            <v-file-input accept="video/*" @change="handleFile"></v-file-input>
          </div>
        </v-stepper-content>
        <v-stepper-content step="2">
          <div>
            <v-text-field label="Book Title" v-model="bookName"></v-text-field>
            <v-btn @click="saveBook">Save Book</v-btn>
          </div>
        </v-stepper-content>
        <v-stepper-content step="3">
          <div>
            Success!
          </div>
        </v-stepper-content>
      </v-stepper-items>
    </v-stepper>
  </div>
</template>

<script>
  import {mapState, mapActions, mapMutations} from 'vuex';

  export default {
    name: "createBook",
    layout: 'index2Layout',
    data: () => ({
      bookName: "",
      step: 1
    }),
    computed: {
      ...mapState('books', ['books']),
      ...mapState('videos', ['uploadPromise']),
    },
    methods: {
      ...mapMutations('videos', {
        resetVideos: 'reset'
      }),
      ...mapActions('videos', ['startVideoUpload']),
      ...mapActions('books', ['addBook']),
      async handleFile(file) {
        if (!file) return;

        const form = new FormData();
        form.append("video", file)
        this.startVideoUpload({form});
        this.step++;
      },
      async saveBook() {
        if (!this.uploadPromise) {
          console.log("uploadPromise is null")
          return;
        }

        const video = await this.uploadPromise;
        await this.addBook({book: {title: this.bookName, video}});
        this.bookName = '';
        this.step++;
        this.resetVideos();
      },
    }
  }
</script>

<style scoped>

</style>
