<template>
  <v-dialog :value="active" persistent>
    <template v-slot:activator="{on}">
      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-btn depressed v-bind="attrs" v-on="on">
            Create
          </v-btn>
        </template>
        <v-list>
          <v-list-item v-for="(item, i) in menuItems" :key="`ccd-menu-${i}`"
                       @click="activate({component:item.component})">

            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </template>

    <div v-if="component">
      <component :is="component"></component>
    </div>

    <div class="d-flex justify-center my-4">
      <v-btn @click="reset">
        Close
      </v-btn>
    </div>
  </v-dialog>
</template>

<script>
  import {mapState, mapMutations} from 'vuex';
  import BookSteps from "./book-steps";
  import SubmissionSteps from "./submission-steps";
  import DifficultyForm from "./difficulty-form";

  export default {
    name: "content-creation-dialog",
    components: {
      SubmissionSteps,
      BookSteps,
      DifficultyForm
    },
    computed: {
      ...mapState('video-upload', ['active', 'component']),
      menuItems() {
        return [
          {component: BookSteps, title: "Book"},
          {component: SubmissionSteps, title: "Submission"},
          {component: DifficultyForm, title: "Difficulty"}
        ]
      }
    },
    methods: mapMutations('video-upload', ['reset', 'activate']),
  }
</script>

<style scoped>

</style>
