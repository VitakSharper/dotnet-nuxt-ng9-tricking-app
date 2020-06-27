import Axios from "axios";

export const state = () => ({
  tricks: []
});


export const mutations = {
  setTricks: (state, tricks) => (
    state.tricks = tricks
  ),
  reset: (state) => {
    state.tricks = []
  }
};

export const actions = {
  fetchTricks: async ({commit}) => {
    const tricks = (await Axios.get('http://localhost:5000/api/tricks')).data;
    console.log('in trick state: ', tricks)
    commit('setTricks', tricks);
  },
  createTricks: async ({commit, dispatch}, {trick}) => {
    await Axios.post('http://localhost:5000/api/tricks', trick);
    await dispatch('fetchTricks');
  }
};

export const getters = {
  // getUsers: s => s.users
};


