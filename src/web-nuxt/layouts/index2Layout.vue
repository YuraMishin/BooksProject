<template>
  <v-app>
    <v-app-bar app dense>
      <v-toolbar-title>Books Project</v-toolbar-title>
      <v-spacer></v-spacer>
      <video-upload/>
    </v-app-bar>
    <v-main>
        <nuxt/>
    </v-main>
  </v-app>
</template>

<script>
  import VideoUpload from "../components/video-upload";
  export default {
    name: "index2Layout",
    components: {VideoUpload}
  }
</script>

<style scoped>

</style>
