const initState = () => ({
  books: [],
  difficulties: []
})

export const state = initState;

export const getters = {
  bookItems: state => state.books.map(x => ({
    text: x.title,
    value: x.id
  })),
  difficultyItems: state => state.difficulties.map(x => ({
    text: x.name,
    value: x.id
  }))
}

// sync
export const mutations = {
  setBooks(state, {books, difficulties}) {
    state.books = books;
    state.difficulties = difficulties;
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
    const difficulties = await this.$axios.$get("difficulties/");
    commit('setBooks', {books, difficulties});
  },
  addBook({dispatch}, {form}) {
    return this.$axios.$post('books/', form);
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
