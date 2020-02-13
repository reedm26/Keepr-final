<template>
  <div class="row">
    <div v-for="publicKeep in publicKeeps" :key="publicKeep.Id" class="col">
      <div class="card" style="width: 18rem;">
        <img class="card-img-top" :src="publicKeep.img" alt="Card image cap" />
        <div class="card-body">
          <h5 class="card-title">{{ publicKeep.name }}</h5>
          <p class="card-text">{{ publicKeep.description }}</p>
          <a href="#" class="btn btn-warning">+</a>
          <a href="#" class="btn btn-danger" @click="deleteKeep(publicKeep)"
            >x</a
          >
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
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
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
    }
  }
};
</script>
<style></style>
