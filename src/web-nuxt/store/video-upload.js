import {UPLOAD_TYPE} from "../data/enum";

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
    if (type === UPLOAD_TYPE.BOOK) {
      state.step++;
    } else if (type === UPLOAD_TYPE.SUBMISSION) {
      state.step += 2;
    }
  },
  setTask(state, {uploadPromise}) {
    state.uploadPromise = uploadPromise
    state.step++
  },
  reset(state) {
    Object.assign(state, initState())
  },
  incStep(state) {
    state.step++;
  },
}

export const actions = {
  startVideoUpload({commit, dispatch}, {form}) {
    const uploadPromise = this.$axios.$post("videos", form);
    commit("setTask", {uploadPromise})
  },
  async addBook({state, dispatch}, {book, submission}) {
    if (state.type === UPLOAD_TYPE.BOOK) {
      const createdBook = await this.$axios.$post('books/', book);
      console.log(createdBook)
      submission.bookId = createdBook.id
    }
    const createdSubmission = await this
      .$axios.$post("submissions/", submission)

    await dispatch("books/fetchBooks", null, {root: true});
    await dispatch("submissions/fetchSubmissions", null, {root: true})
  },
}
