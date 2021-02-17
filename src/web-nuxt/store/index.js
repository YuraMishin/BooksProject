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
  },
  editBook(state, editedBook) {
    const bookIndex = state.loadedBooks.findIndex(
      book => book.id === editedBook.id
    );
    state.loadedBooks[bookIndex] = editedBook
  }
}

export const actions = {
  nuxtServerInit(vuexContext, context) {
    return this.$axios.get()
      .then(response => {
        vuexContext.commit("setBooks", response.data);
      })
      .catch(e => context.error(e))
  },
  addBook(vuexContext, book) {
    return this.$axios
      .post('', book)
      .then(result => {
        vuexContext.commit('addBook', book)
      })
      .catch(e => console.log(e));
  },
  editBook(vuexContext, editedBook) {
    return this.$axios
      .put(`${editedBook.id}`, editedBook)
      .then(res => {
        vuexContext.commit('editBook', editedBook)
      })
      .catch(e => console.log(e))
  },
}
