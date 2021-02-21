const initState = () => ({
  books: [],
})

export const state = initState;

// sync
export const mutations = {
  setBooks(state, {books}) {
    state.books = books;
  },
  reset(state) {
    Object.assign(state, initState());
  },
  addBook(state, book) {
    state.books.push(book)
  },
  editBook(state, editedBook) {
    const bookIndex = state.books.findIndex(
      book => book.id === editedBook.id
    );
    state.books[bookIndex] = editedBook
  }
}

// async
export const actions = {
  async fetchBooks({commit}) {
    const books = (await this.$axios.$get('books/'));
    commit('setBooks', {books});
  },
  async addBook({dispatch}, {book}) {
    // console.log(book);
    await this.$axios.$post('books/', book);
    await dispatch("fetchBooks");
  },
  async addBook2(vuexContext, book) {
    return this.$axios
      .post('books/', book)
      .then(result => {
        vuexContext.commit('addBook', book)
      })
      .catch(e => console.log(e));
  },
  async editBook2(vuexContext, editedBook) {
    return this.$axios
      .put(`books/${editedBook.id}`, editedBook)
      .then(res => {
        vuexContext.commit('editBook', editedBook)
      })
      .catch(e => console.log(e))
  }
}
