import Axios from "axios";

const initState = () => ({
  message: 'init',
  baseUrl: 'http://localhost:5000/api/home/index'
})

export const state = initState;

export const mutations = {
  setMessage: (state, message) => {
    state.message = message
  },
  reset: (state) => {
    Object.assign(state, initState())
  }
}

export const actions = {
  // mode: 'universal' in nuxt.config.js
  nuxtServerInit: async ({commit, dispatch}) => {
    const message = (await Axios.get('http://localhost:5000/api/home/index')).data;
    console.log('in store actions: ', message)
    commit('setMessage', message);
    dispatch('tricks/fetchTricks')
  }
}
