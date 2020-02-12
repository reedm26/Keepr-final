<template>
  <div class="home container-fluid">
    <h1>Home</h1>
    <h4>Public Keeps</h4>
    <div>
      <keep />
    </div>
  </div>
</template>

<script>
import keep from "@/components/KeepComponent.vue";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    keep
  }
};
</script>
