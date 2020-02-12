<template>
  <div class="row">
    <div v-for="publicKeep in publicKeeps" :key="publicKeep.Id">
      <div class="card" style="width: 18rem;">
        <img class="card-img-top col-3" :src="publicKeep.img" alt="Card image cap" />
        <div class="card-body">
          <h5 class="card-title">{{publicKeep.name}}</h5>
          <p class="card-text">{{publicKeep.description}}</p>
          <a href="#" class="btn btn-primary">Go somewhere</a>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "keep",
  mounted() {
    this.$store.dispatch("publicKeeps");
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  }
};
</script>
<style></style>
