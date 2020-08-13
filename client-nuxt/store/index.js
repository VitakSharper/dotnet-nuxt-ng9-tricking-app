const initState = () => ({})

export const state = initState;

export const mutations = {
  reset: (state) => {
    Object.assign(state, initState())
  }
}

export const actions = {
  // mode: 'universal' in nuxt.config.js
  async nuxtServerInit() {
  }
}
