<template>
  <div v-if="showLoading">
    <img src="../../assets/loading.svg" alt="" />
  </div>
</template>
<script>
export default {
  name: "BaseLoading",

  props: ["showLoading"],
  methods: {
    btnAddOnClick() {
      this.isHideParent = false;
    },
    rowOnClick(employee) {
      alert(employee.FullName);
    },
    closePopup(value) {
      this.isHideParent = value;
    },
    cancelLoading() {
      return false;
    },
  },

  data() {
    return {
      isLoading: false,
      canCancel: false,
      color: "#019160",
      loader: "dots", // bars dots spinner
      onCancel: this.cancelLoading,
      width: 50,
      height: 50,
      backgroundColor: "#000",
      fullPage: false,
      opacity: 0.2,
      isHideParent: true,
      blur: "15px",
    };
  },
};
</script>
<style scoped>
div {
  position: absolute;
  width: 100%;
  height: 100%;
  display: flex;
  z-index: 20;
  justify-content: center;
  align-items: center;
}
div img {
  position: absolute;
  width: 48px;
  height: 48px;
  -webkit-animation: spin 4s linear infinite;
  -moz-animation: spin 4s linear infinite;
  animation: spin 1s linear infinite;
}
@-moz-keyframes spin {
  100% {
    -moz-transform: rotate(360deg);
  }
}
@-webkit-keyframes spin {
  100% {
    -webkit-transform: rotate(360deg);
  }
}
@keyframes spin {
  100% {
    -webkit-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
</style>
