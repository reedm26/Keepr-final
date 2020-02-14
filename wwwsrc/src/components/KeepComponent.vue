<template>
  <div class="row">
    <div v-for="publicKeep in publicKeeps" :key="publicKeep.Id" class="col">
      <div class="card" style="width: 18rem;">
        <img class="card-img-top" :src="publicKeep.img" alt="Card image cap" />
        <div class="card-body">
          <h5 class="card-title">{{ publicKeep.name }}</h5>
          <p class="card-text">{{ publicKeep.description }}</p>

          <i
            href="#"
            class="btn btn-danger fa fa-ban"
            @click="deleteKeep(publicKeep)"
          ></i>
          <button @click="setActiveKeep(publicKeep)">
            view</button
          >{{ publicKeep.views }} <button>Shares</button
          >{{ publicKeep.shares }} <button>Keeps</button>{{ publicKeep.keeps }}
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import swal from "vue-sweetalert2";
export default {
  name: "keep",
  mounted() {
    // this.store.dispatch("getVaultKeeps");
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  data() {
    return {};
  },
  methods: {
    deleteKeep(publicKeep) {
      if (confirm("Are you sure you want to delete this keep?")) {
        this.$store.dispatch("deleteKeep", publicKeep);
      }
    },

    setActiveKeep(publicKeep) {
      this.$store.dispatch("setActiveKeep", publicKeep);
      this.$router.push({ path: "/activekeep" });
    }
  }
};
</script>
<style></style>
