<template>
  <div>
    <div v-if="item">
      {{item.description}}
    </div>

    <comment-section :comments="comments" @send="send"/>

    <!--    <div class="my-1" v-for="c in comments">-->

    <!--      <v-btn small @click="replyId = c.id">Reply</v-btn>-->
    <!--      <v-btn small @click="loadReplies(c)">Load Replies</v-btn>-->
    <!--      <div v-for="r in c.replies">-->
    <!--        <span v-html="r.htmlContent"></span>-->
    <!--      </div>-->
    <!--    </div>-->
  </div>
</template>

<script>
  import CommentSection from "../../../../../components/v2/comments/comment-section";
  const endpointResolver = (type) => {
    if (type === 'book') return 'books'
  }
  const commentWithReplies = comment => ({
    ...comment,
    replies: []
  });
  export default {
    layout: 'index2Layout',
    components: {CommentSection},
    data: () => ({
      item: null,
      comments: [],
      comment: "",
      replyId: 0,
    }),
    created() {
      const {modId, type, bookId} = this.$route.params
      const endpoint = endpointResolver(type)
      this.$axios.$get(`${endpoint}/${bookId}`)
        .then((item) => this.item = item)
      this.$axios.$get(`moderation-items/${modId}/comments`)
        .then((comments) => this.comments = comments.map(commentWithReplies))
    },
    methods: {
      send(content) {
        const {modId} = this.$route.params
        return this.$axios.$post(`moderation-items/${modId}/comments`,
          {content})
          .then((comment) => this.comments.push(comment))
      },
    }
  }
</script>

<style scoped>
</style>
