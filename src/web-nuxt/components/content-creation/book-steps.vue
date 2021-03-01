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
          <v-text-field label="Title" v-model="form.title"></v-text-field>
          <v-text-field label="Description" v-model="form.description"></v-text-field>
          <v-select
            :items="difficultyItems"
            v-model="form.difficulty"
            label="Difficulty"></v-select>
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
  import {mapState, mapGetters, mapActions, mapMutations} from 'vuex';

  const initState = () => ({
    step: 1,
    form: {
      title: "",
      description: "",
      difficulty: "",
    }
  })

  export default {
    name: "book-steps",
    data: initState,
    computed: {
      ...mapState('video-upload', ['active']),
      ...mapGetters('books', ['difficultyItems']),
    },
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
