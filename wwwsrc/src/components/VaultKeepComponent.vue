<template>
  <div class="row">
    <div v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id" class="col">
      <div class="card" style="width: 18rem;">
        <img class="card-img-top" :src="publicKeep.img" alt="Card image cap" />
        <div class="card-body">
          <h5 class="card-title">{{ publicKeep.name }}</h5>
          <p class="card-text">{{ publicKeep.description }}</p>
          <a @click.prevent="addKeepToVault" href="#" class="btn btn-warning"
            >+</a
          >
          <a href="#" class="btn btn-danger" @click="deleteKeep(publicKeep)"
            >x</a
          >
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "vaultkeep",
  mounted() {
    this.store.dispatch("getVaultKeeps");
  },
  computed: {
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  }
};
</script>
