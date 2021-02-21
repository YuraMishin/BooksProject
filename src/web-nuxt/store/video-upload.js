const initState = () => ({
  uploadPromise: null,
  active: false,
  type: "",
  step: 1,
})

export const state = initState

export const mutations = {
  toggleActivity(state) {
    state.active = !state.active
    if (!state.active) {
      Object.assign(state, initState())
    }
  },
  setType(state, {type}) {
    state.type = type
    state.step++
  },
  setTask(state, {uploadPromise}) {
    state.uploadPromise = uploadPromise
    state.step++
  },
  reset(state) {
    Object.assign(state, initState())
  }
}

export const actions = {
  startVideoUpload({commit, dispatch}, {form}) {
    const uploadPromise = this.$axios.$post("videos", form);
    commit("setTask", {uploadPromise})
  },
  async addBook({dispatch}, {book}) {
    await this.$axios.$post('books/', book);
    await dispatch("books/fetchBooks", null, {root: true});
  },
}
