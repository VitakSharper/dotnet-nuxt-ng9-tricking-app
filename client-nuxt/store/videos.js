const initState = () => ({
  uploadPromise: null
})

export const state = initState;

export const mutations = {
  setTask: (state, {task}) => (
    state.uploadPromise = task
  ),
  reset: (state) => {
    Object.assign(state, initState())
  }
};

export const actions = {
  async startVideoUpload({commit, dispatch}, {form}) {
    const task = this.$axios.$post('http://localhost:5000/api/videos', form)
    commit('setTask', {task})
  }
};

export const getters = {
  // getUsers: s => s.users
};


