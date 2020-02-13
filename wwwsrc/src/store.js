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
    activeKeep: {}
  },
  mutations: {
    allKeeps(state, data) {
      state.publicKeeps = data;
    },
    createKeep(state, keep) {
      state.publicKeeps.push(keep);
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
    async addKeep({ commit, dispatch }, keep) {
      let res = await api.post("keeps", keep);
      commit("createKeep", res.data);
    },
    async deleteKeep({ commit, dispatch }, publicKeep) {
      let res = await api.delete("keeps/" + publicKeep.id);
      dispatch("allKeeps");
    }
  }
});
