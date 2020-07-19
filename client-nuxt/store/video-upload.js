const initState = () => ({
  uploadPromise: null,
  active: false,
  type: '',
  step: 1
})


export const state = initState;

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
};

export const actions = {
  async startVideoUpload({commit, dispatch}, {form}) {
    const uploadPromise = await this.$axios.$post(`http://localhost:5000/api/videos`, form)
    commit('setTask', {uploadPromise})
  },
  async createTricks({commit, dispatch}, {trick}) {
    await this.$axios.$post(`http://localhost:5000/api/tricks`, trick);
  }
};

export const getters = {
  // getUsers: s => s.users
};


