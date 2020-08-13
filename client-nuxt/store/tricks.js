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
  createTrick({state, commit, dispatch}, {form}) {
    return this.$axios.$post(`http://localhost:5000/api/tricks`, form);
  }
};
