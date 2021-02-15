<template>
  <nuxt-link :to="bookLink" class="book-preview">
    <article>
      <div
        class="book-thumbnail"
      >
      </div>
      <div class="book-content">
        <h1>{{ title }}</h1>
      </div>
    </article>
  </nuxt-link>
</template>

<script>
  export default {
    name: 'BookPreview',
    props: {
      id: {
        type: String,
        required: true
      },
      title: {
        type: String,
        required: true
      },
    },
    computed: {
      bookLink() {
        return `/books/${this.id}`
      }
    }
  }
</script>

<style scoped>
  .book-preview {
    border: 1px solid #ccc;
    box-shadow: 0 2px 2px #ccc;
    background-color: white;
    width: 90%;
  }

  a {
    text-decoration: none;
    color: black;
  }

  @media (min-width: 850px) {
    .book-preview {
      width: 400px;
      margin: 10px;
    }
  }

  .book-thumbnail {
    width: 100%;
    height: 200px;
    background-position: center;
    background-size: cover;
  }

  .book-content {
    padding: 10px;
    text-align: center;
  }

  a:hover .book-content,
  a:active .book-content {
    background-color: #ccc;
  }
</style>
