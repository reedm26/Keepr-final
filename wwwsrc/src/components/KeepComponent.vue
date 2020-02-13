<template>
  <div class="row">
    <div v-for="publicKeep in publicKeeps" :key="publicKeep.Id">
      <div class="card" style="width: 18rem;">
        <img class="card-img-top" :src="publicKeep.img" alt="Card image cap" />
        <div class="card-body">
          <h5 class="card-title">{{ publicKeep.name }}</h5>
          <p class="card-text">{{ publicKeep.description }}</p>
          <a href="#" class="btn btn-warning">+</a>
          <a href="#" class="btn btn-danger" onclick="deleteKeep()">x</a>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import swal from "sweetalert2";
export default {
  name: "keep",
  mounted() {
    this.$store.dispatch("publicKeeps");
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    deleteKeep(keepId) {
      swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this keep!",
        icon: "warning",
        buttons: true,
        dangerMode: true
      }).then(willDelete => {
        if (willDelete) {
          swal("Poof! That keep has been deleted!", {
            icon: "success"
          });
        } else {
          swal("Your imaginary file is safe!");
        }
      });
    }
  }
};
</script>
<style></style>
