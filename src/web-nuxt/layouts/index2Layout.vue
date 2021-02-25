<template>
  <v-app>
    <v-app-bar app dense>
      <v-toolbar-title>Books Project</v-toolbar-title>
      <v-spacer></v-spacer>

      <content-creation-dialog></content-creation-dialog>

    </v-app-bar>
    <v-main>
        <nuxt/>
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
