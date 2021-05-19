<template>
  <AppLayout> </AppLayout>
</template>

<script>
import AppLayout from "./layouts/AppLayout";
import "vue-search-select/dist/VueSearchSelect.css";

export default {
  name: "App",
  components: {
    AppLayout,
  },
};
</script>

<style>
@import "./styles/common.css";
@import "./styles/main.css";
</style>
