﻿<template>
  <div>
    <comment-body :comment="comment" @send="send" @load-replies="loadReplies" />
    <div class="ml-5">
      <comment-body v-for="(reply, index) in replies" :key="index" :comment="reply"
                    @send="send"/>
    </div>
  </div>
</template>

<script>
  import CommentBody from "./comment-body";

  export default {
    name: "comment",
    components: {CommentBody},
    props: {
      comment: {
        required: true,
        type: Object,
      }
    },
    data: () => ({
      replies: []
    }),
    methods: {
      send(content) {
        return this.$axios.$post(`comments/${this.comment.id}/replies`,
          {content})
          .then((comment) => this.replies.push(comment))
      },
      loadReplies() {
        this.$axios.$get(`comments/${this.comment.id}/replies`)
          .then((replies) => this.replies = replies)
      }
    }
  }
</script>

<style scoped>

</style>
