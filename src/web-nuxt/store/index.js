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
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        vuexContext.commit("setBooks", [
          {
            id: "1",
            title: "Book1"
          },
          {
            id: "2",
            title: "Book2"
          },
        ]);
        resolve();
      }, 1000);
    });
  }
}
