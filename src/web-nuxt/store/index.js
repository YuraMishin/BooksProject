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
  }
}

export const actions = {
  nuxtServerInit(vuexContext, context) {
    return this.$axios.get('http://localhost:5000/api/books')
      .then(response => {
        vuexContext.commit("setBooks", response.data);
      })
      .catch(e => context.error(e))
  }
}
