<template>
  <div>
    <h1>File Upload</h1>
    <v-file-input
      @change="handleFile"
      accept="video/*"
    />
  </div>
</template>

<script>
  export default {
    name: "fileupload",
    layout: 'index2Layout',
    methods: {
      async handleFile(file) {
        if (!file) return;
        const form = new FormData();
        form.append("video", file);

        console.log(form.getAll('video'));

        const result = await this.$axios
          .$post("videos", form);
      }
    }
  }
</script>

<style scoped>

</style>
