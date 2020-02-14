<template>
  <div class="row">
    <div class="col-3">
      <h3 class="text-center">
        Your Keep
        {{ activeKeep.name }}
        {{ activeKeep.views }}
        <h4>Vault keep</h4>
        {{ vaultKeeps.length }}
        {{ vaults }}
      </h3>
    </div>
    <div class="col-3">
      <div class="dropdowns">
        <select
          name="vaults"
          id="options"
          @change="addVaultKeep(activeKeep.id, $event)"
          >Pick a vault
          <option value selected disabled>Select A Vault</option>
          <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{
            vault.name
          }}</option>
        </select>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ActiveKeep",
  data() {
    return {
      vaultKeep: {
        vaultId: "",
        keepId: ""
      }
    };
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    vaults() {
      return this.$store.state.vaults;
    },
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {
    addVaultKeep() {
      debugger;
      var option = document.getElementById("options");
      let vaultId = option.options[option.selectedIndex].value;
      var id = parseInt(vaultId, 10);
      this.vaultKeep.keepId = this.activeKeep.id;
      this.vaultKeep.vaultId = id;
      debugger;
      console.log(this.vaultKeep);
      this.$store.dispatch("addVaultKeep", this.vaultKeep);
    }
  }
};
</script>

<style></style>
