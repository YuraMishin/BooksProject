<template>
  <div>
    <div v-if="item">
      {{item.description}}
    </div>
  </div>
</template>

<script>

  const endpointResolver = (type) => {
    if (type === 'book') return 'books'
  }

  export default {
    layout: 'index2Layout',
    data: () => ({
      item: null
    }),
    async fetch() {
      const {type, id} = this.$route.params
      const endpoint = endpointResolver(type)
      this.item = await this.$axios.$get(`${endpoint}/${id}/`)
    }
  }
</script>

<style scoped>

</style>
