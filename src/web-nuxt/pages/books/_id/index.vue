<template>
  <div class="single-book-page">
    <section class="book">
      <h1 class="book-title">{{ loadedBook.title }}</h1>
      <div class="book-details">
        <div class="book-detail">Last updated on foo</div>
        <div class="book-detail">Written by foo</div>
      </div>
      <p class="book-content">foo</p>
    </section>
    <section class="book-feedback">
      <p>Let me know what you think about the book, send a mail to <a
        href="mailto:feedback@domain.com">feedback@domain.com</a>.</p>
    </section>
  </div>
</template>

<script>
export default {
  asyncData(context, callback) {
    setTimeout(() => {
      callback(null, {
        loadedBook: {
          id: "1",
          title: `First book (ID:  ${context.route.params.id})`
        }
      });
    }, 1000);
  }
};
</script>

<style scoped>
.single-book-page {
  padding: 30px;
  text-align: center;
  box-sizing: border-box;
}

.book {
  width: 100%;
}

@media (min-width: 768px) {
  .book {
    width: 600px;
    margin: auto;
  }
}

.book-title {
  margin: 0;
}

.book-details {
  padding: 10px;
  box-sizing: border-box;
  border-bottom: 3px solid #ccc;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}

@media (min-width: 768px) {
  .book-details {
    flex-direction: row;
  }
}

.book-detail {
  color: rgb(88, 88, 88);
  margin: 0 10px;
}

.book-feedback a {
  color: red;
  text-decoration: none;
}

.book-feedback a:hover,
.book-feedback a:active {
  color: salmon;
}
</style>
