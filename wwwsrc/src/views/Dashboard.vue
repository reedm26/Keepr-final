<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12 d-flex">
        <h1>My Dashboard</h1>
        <form>
          <div v-if="show" class="form-row">
            <div class="col-4">
              <input
                v-model="newVault.name"
                type="text"
                class="form-control"
                placeholder="name"
              />
            </div>
            <div class="col-4">
              <input
                v-model="newVault.description"
                type="text"
                class="form-control"
                placeholder="description"
              />
            </div>
            <div class="col-4">
              <button
                @click="addVault"
                type="button"
                class="btn btn-outline-success"
              >
                add
              </button>
            </div>
          </div>
        </form>
        <form>
          <div class="form-row align-items-center">
            <div class="col-9 m-1">
              <button @click="show = !show" class="btn btn-sm btn-success">
                +vault
              </button>
              <label class="mr-sm-2 sr-only"></label>
              <select class="custom-select mr-sm-2">
                <option selected>Vault</option>
                <option value="1">One</option>
                <option value="2">Two</option>
                <option value="3">Three</option>
              </select>
            </div>
          </div>
        </form>
      </div>
    </div>
    <div class="row">
      <div v-for="vault in vaults" :key="vault.id" class="col-6">
        <div class="btn">
          <button type="button" class="btn btn-outline-secondary m-2">
            {{ vault.name }}
            <p @click="deleteVault(vault)" class="">x</p>
          </button>
        </div>
      </div>
      <h3 class="text-center">Your Keeps</h3>
      <keep />
    </div>
  </div>
</template>

<script>
import keep from "@/components/KeepComponent.vue";
// import vaultkeep from "@/components/VaultKeepComponent.vue";
export default {
  name: "dashboard",
  data() {
    return {
      newVault: {
        name: "",
        description: ""
      },
      show: false
    };
  },
  mounted() {
    this.$store.dispatch("getVaultKeeps");
    this.$store.dispatch("getVaults");
  },
  methods: {
    addVault() {
      let vault = { ...this.newVault };
      this.$store.dispatch("addVault", vault);
      this.newVault = {
        name: "",
        description: ""
      };
    },
    deleteVault(vault) {
      if (confirm("Are you sure you want to delete this vault?")) {
        this.$store.dispatch("deleteVault", vault);
      }
    }
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  components: {
    keep
  }
};
</script>

<style></style>
