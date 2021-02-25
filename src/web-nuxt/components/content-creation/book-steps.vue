<template>
  <v-stepper v-model="step">
    <v-stepper-header>
      <v-stepper-step :complete="step > 1" step="1">Book Information</v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step step="2">Review</v-stepper-step>
    </v-stepper-header>

    <v-stepper-items>
      <v-stepper-content step="1">
        <div>
          <v-text-field label="Book Title" v-model="form.title"></v-text-field>
          <v-btn @click="step++">Next</v-btn>
        </div>
      </v-stepper-content>

      <v-stepper-content step="2">
        <div>
          <v-btn @click="save">Save</v-btn>
        </div>
      </v-stepper-content>
    </v-stepper-items>
  </v-stepper>
</template>

<script>
  import {mapState, mapActions, mapMutations} from 'vuex';

  const initState = () => ({
    step: 1,
    form: {
      title: "",
    }
  })

  export default {
    name: "book-steps",
    data: initState,
    computed: mapState('video-upload', ['active']),
    watch: {
      'active': function (newValue) {
        if (!newValue) {
          Object.assign(this.$data, initState())
        }
      }
    },
    methods: {
      ...mapMutations('video-upload', ['reset']),
      ...mapActions('books', ['addBook']),
      async save() {
        await this.addBook({form: this.form})
        this.reset();
        Object.assign(this.$data, initState())
      },
    }
  }
</script>

<style scoped>

</style>
