export const state = () => ({
  tricks: []
});


export const mutations = {
  setTricks(state, tricks) {
    state.tricks = tricks
  },
  reset(state) {
    state.tricks = []
  }
};

export const actions = {
  async fetchTricks({commit}) {
    const tricks = await this.$axios.$get(`http://localhost:5000/api/tricks`);
    commit('setTricks', tricks);
  },
  async createTricks({commit, dispatch}, {trick}) {
    await this.$axios.$post(`http://localhost:5000/api/tricks`, trick);
    await dispatch('fetchTricks');
  }
};

export const getters = {
  // getUsers: s => s.users
};


