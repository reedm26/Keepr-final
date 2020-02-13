<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col">
        <h1>My-Vaults</h1>
        <button @click="show" class="btn btn-success">+ vault</button>
        <form>
          <div class="form-row align-items-center">
            <div class="col-auto my-1">
              <label class="mr-sm-2 sr-only"></label>
              <select class="custom-select mr-sm-2">
                <option selected>Choose...</option>
                <option value="1">{{ One }}</option>
                <option value="2">Two</option>
                <option value="3">Three</option>
              </select>
            </div>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  mounted() {},
  computed: {}
};
</script>

<style></style>
