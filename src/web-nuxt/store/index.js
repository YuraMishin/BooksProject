const initState = () => ({})

export const state = initState;

// sync
export const mutations = {}

// async
export const actions = {
  async nuxtServerInit({dispatch}) {
    await dispatch("books/fetchBooks");
    await dispatch("submissions/fetchSubmissions")
  }
}
