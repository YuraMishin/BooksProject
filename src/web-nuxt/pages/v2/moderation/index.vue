<template>
  <div>
    <v-btn
      :to="`/v2/moderation/${i.type}/${i.target}`"
      :key="i.id"
      v-for="i in items">
      {{i.target}}
    </v-btn>
  </div>
</template>

<script>
  import {mapGetters} from 'vuex';

  export default {
    layout: 'index2Layout',
    data: () => ({
      items: [],
      book: null
    }),
    methods: {
      ...mapGetters('books', ['bookById'])
    },
    async fetch() {
      this.items = await this.$axios.$get("moderation-items/");
    }
  }
</script>

<style scoped>

</style>
