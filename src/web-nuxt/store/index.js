const initState = () => ({})

export const state = initState;

// sync
export const mutations = {}

// async
export const actions = {
  nuxtServerInit({dispatch}) {
    return dispatch("books/fetchBooks");
    // await dispatch("submissions/fetchSubmissions")
  }
}
