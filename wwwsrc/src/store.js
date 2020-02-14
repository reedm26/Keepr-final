import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    privateKeeps: [],
    vaults: [],
    activeKeep: {},
    vaultKeeps: [],
    activeVault: {}
  },
  mutations: {
    allKeeps(state, data) {
      state.publicKeeps = data;
    },
    createKeep(state, keep) {
      state.publicKeeps.push(keep);
    },
    // allPrivateKeeps(state, data) {
    //   state.privateKeeps = data;
    // },
    allVaults(state, data) {
      state.vaults = data;
    },
    createVault(state, vault) {
      state.vaults.push(vault);
    },
    createVaultKeep(state, vaultKeep) {
      state.vaultKeeps.push(vaultKeep);
    },
    allVaultKeeps(state, data) {
      state.vaultKeeps = data;
    },
    setActiveKeep(state, ActKeep) {
      state.activeKeep = ActKeep;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getPublicKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      commit("allKeeps", res.data);
    },
    async getVaultKeeps({ commit, dispatch }, vaultId) {
      let res = await api.get("vaultkeeps/" + vaultId + "/keeps");
      commit("allVaultKeeps", res.data);
    },

    // async getPrivateKeeps({ commit, dispatch }, privateKeep) {
    //   let res = await api.get("keeps/" + privateKeep.id);
    //   commit("allPrivateKeeps", res.data);
    // },
    async addVaultKeep({ commit, dispatch }, vaultKeep) {
      let res = await api.post("vaultKeeps", vaultKeep);
      commit("createVaultKeep", res.data);
      console.log(res.data, "this is from vaultKeep");
      console.log(vaultKeep);
    },
    async addKeep({ commit, dispatch }, keep) {
      let res = await api.post("keeps", keep);
      commit("createKeep", res.data);
    },
    async deleteKeep({ commit, dispatch }, publicKeep) {
      let res = await api.delete("keeps/" + publicKeep.id);
      dispatch("getPublicKeeps");
    },
    async getVaults({ commit, dispatch }) {
      let res = await api.get("vaults");
      commit("allVaults", res.data);
    },
    async addVault({ commit, dispatch }, vault) {
      let res = await api.post("vaults", vault);
      commit("createVault", res.data);
    },
    async deleteVault({ commit, dispatch }, vault) {
      let res = await api.delete("vaults/" + vault.id);
      dispatch("allVaults");
    },
    async setActiveKeep({ commit, dispatch }, keep) {
      let res = await api.get("keeps/" + keep.id);
      commit("setActiveKeep", res.data);
      console.log(res.data);
    }
  }
});
