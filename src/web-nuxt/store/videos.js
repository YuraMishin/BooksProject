const initState = () => ({
  uploadPromise: null
})

export const state = initState

export const mutations = {
  setTask(state, {uploadPromise}) {
    state.uploadPromise = uploadPromise
  },
  reset(state) {
    Object.assign(state, initState())
  }
}

export const actions = {
  startVideoUpload({commit, dispatch}, {form}) {
    // upload video
    const uploadPromise = this.$axios
      .$post("http://localhost:5000/api/videos", form);
    // save result
    commit("setTask", {uploadPromise})
  }
}
