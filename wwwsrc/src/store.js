import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "//localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "//localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    }
  },
  actions: {
    // AUTH
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', {})
          router.push({ name: 'login' })
        })
    },
    createAccount({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', {})
          router.push({ name: 'login' })
        })
    },

    // KEEPS
    getKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
        .catch(e => {
          console.log(e)
        })
    },
    addKeep({ commit, dispatch }, keepData) {
      api.post('keeps', keepData)
        .then(res => {
          dispatch('getKeeps')
        })
    },
    addKeepView({ commit, dispatch }, keepId) {
      api.get(`keeps/${keepId}/addView`)
        .then(res => {
          dispatch('getKeeps')
        })
    },
    addKeepShare({ commit, dispatch }, keepId) {
      api.get(`keeps/${keepId}/addShare`)
        .then(res => {
          dispatch('getKeeps')
        })
    },
    deleteKeep({ commit, dispatch }, keepId) {
      api.delete('keeps/' + keepId)
        .then(res => {
          dispatch('getKeeps')
        })
        .catch(e => {
          console.log('error:', e)
        })
    },

    // VAULTS
    getVaults({ commit, dispatch }, id) {
      api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
        .catch(e => {
          console.log(e)
        })
    },
    getVaultsByUserId({ commit, dispatch }, id) {
      api.get('vaults/byuser/' + id)
        .then(res => {
          commit('setVaults', res.data)
        })
        .catch(e => {
          console.log(e)
        })
    },
    addVault({ commit, dispatch }, vaultData) {
      api.post('vaults', vaultData)
        .then(res => {
          dispatch('getVaults')
        })
    },
    addKeepToVault({ commit, dispatch }, vkData) {
      api.post('vaultkeep', vkData)
        .catch(e => {
          console.log('error:', e)
        })
    },
    deleteVault({ commit, dispatch }, vaultId) {
      api.delete('vaults/' + vaultId)
        .then(res => {
          dispatch('getVaults')
        })
        .catch(e => {
          console.log('error:', e)
        })
    },
  }
})