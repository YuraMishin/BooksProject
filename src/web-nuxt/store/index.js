const state = () => ({
  loadedBooks: []
})

export const getters = {
  loadedBooks(state) {
    return state.loadedBooks;
  }
}

export const mutations = {
  setBooks(state, books) {
    state.loadedBooks = books;
  },
  addBook(state, book) {
    state.loadedBooks.push(book)
  }
}

export const actions = {
  nuxtServerInit(vuexContext, context) {
    return this.$axios.get('http://localhost:5000/api/books')
      .then(response => {
        vuexContext.commit("setBooks", response.data);
      })
      .catch(e => context.error(e))
  },
  addBook(vuexContext, book) {
    return this.$axios
      .post("http://localhost:5000/api/books/", book)
      .then(result => {
        vuexContext.commit('addBook', book)
      })
      .catch(e => console.log(e));
  },
}
