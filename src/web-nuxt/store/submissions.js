const initState = () => ({
  submissions: []
})

export const state = initState

export const mutations = {
  setSubmissions(state, {submissions}) {
    state.submissions = submissions
  },
  reset(state) {
    Object.assign(state, initState())
  }
}

export const actions = {
  async fetchSubmissionsForBook({commit}, {bookId}) {
    const submissions = await this.$axios.$get(`books/${bookId}/submissions`);
    commit("setSubmissions", {submissions})
  },
  createSubmission({state, commit, dispatch}, {form}) {
    return this.$axios.$post("/submissions", form)
  }
}
