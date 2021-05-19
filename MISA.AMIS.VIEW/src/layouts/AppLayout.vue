<template>
  <div>
    <TheNavbar> </TheNavbar>
    <div class="body-right">
      <TheHeader> </TheHeader>
      <router-view />
    </div>
  </div>
</template>

<script>
import TheNavbar from "./TheNavbar.vue";
import TheHeader from "./TheHeader.vue";

export default {
  name: "AppLayout",
  components: {
    TheNavbar,
    TheHeader,
  },
};
</script>

<style scoped>
div {
  display: flex;
}
.body-right {
  flex: 1;
  top: 0;
  right: 0;
  bottom: 0;
  background-color: #f4f5f6;
  flex-direction: column;
  overflow: hidden;
  position: relative;
}
.body-right .content {
  padding: 0px 30px 0px 0px;
  height: calc(100vh - 50px);
  margin-left: 20px;
}
</style>
