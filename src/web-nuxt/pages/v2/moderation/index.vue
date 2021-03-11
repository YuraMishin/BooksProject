<template>
  <div>
    <v-btn
      :to="`/v2/moderation/${i.id}/${i.type}/${i.target}`"
      :key="i.id"
      v-for="i in items">
      {{i.target}}
    </v-btn>
  </div>
</template>

<script>
  export default {
    layout: 'index2Layout',
    data: () => ({
      items: []
    }),
    async fetch() {
      this.items = await this.$axios.$get("moderation-items/")
    }
  }
</script>

<style scoped>

</style>
