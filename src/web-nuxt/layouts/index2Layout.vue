<template>
  <v-app>
    <v-app-bar app dense>
      <nuxt-link
        class="text-h5 text--primary"
        style="text-decoration: none"
        to="/v2/"
      >
        Books Project
      </nuxt-link>
      <v-spacer></v-spacer>

      <v-btn depressed to="/v2/moderation">Moderation</v-btn>
      <content-creation-dialog></content-creation-dialog>

    </v-app-bar>
    <v-main>
      <v-container>
        <nuxt/>
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
  import ContentCreationDialog
    from "../components/content-creation/content-creation-dialog";

  export default {
    name: "index2Layout",
    components: {ContentCreationDialog}
  }
</script>

<style scoped>

</style>
