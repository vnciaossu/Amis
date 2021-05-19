<template>
  <div class="body-left">
    <div class="sidebar">
      <div class="toggle" @click="toggleMenu"></div>
      <router-link to="/Employee">
        <div class="logo" :class="{ isToggle: isToggle }"></div>
      </router-link>
    </div>
    <div class="menu">
      <router-link
        v-for="(item, index) in menuItem"
        :key="index"
        :to="item.path"
      >
        <div class="menu-item">
          <div :class="item.class"></div>
          <div class="item-name" :class="{ isToggle: isToggle }">
            {{ item.name }}
          </div>
        </div>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "TheSideBar",
  data() {
    return {
      menuItem: [
        {
          path: "/Alert",
          class: "icon icon-overview",
          name: "Tổng quan",
        },
        {
          path: "",
          class: "icon icon-money",
          name: "Tiền mặt",
        },
        {
          path: "",
          class: "icon icon-deposit",
          name: "Tiền gửi",
        },
        {
          path: "",
          class: "icon icon-purchase",
          name: "Mua hàng",
        },
        {
          path: "/Employee",
          class: "icon icon-sell",
          name: "Bán hàng",
        },
        {
          path: "",
          class: "icon icon-bill",
          name: "Quản lý hoá đơn",
        },
        {
          path: "",
          class: "icon icon-storeroom",
          name: "Kho",
        },
        {
          path: "",
          class: "icon icon-tool",
          name: "Công cụ dụng cụ",
        },
        {
          path: "",
          class: "icon icon-asset",
          name: "Tài sản cố định",
        },
        {
          path: "",
          class: "icon icon-tax",
          name: "Thuế",
        },
        {
          path: "",
          class: "icon icon-price",
          name: "Giá thành",
        },
        {
          path: "",
          class: "icon icon-general",
          name: "Tổng hợp",
        },
        {
          path: "",
          class: "icon icon-budget",
          name: "Ngân sách",
        },
        {
          path: "",
          class: "icon icon-report",
          name: "Báo cáo",
        },
        {
          path: "",
          class: "icon icon-analyst",
          name: "Phân tích tài chính",
        },
      ],
    };
  },
  computed: {
    isToggle() {
      return this.$store.getters.getToggle;
    },
  },
  methods: {
    toggleMenu() {
      this.$store.commit("toggleSideBar");
    },
  },
};
</script>

<style>
a {
  text-decoration: none;
  color: #fff;
}
.body-left {
  background-color: #38393d;
  width: 178px;
  height: 100vh;
  border-right: 1px solid #bbbbbb;
  display: flex;
  flex-direction: column;
}

.body-left .sidebar {
  height: 50px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.body-left .sidebar .toggle {
  width: 24px;
  height: 24px;
  margin-right: 10px;
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -424px -86px;
  cursor: pointer;
}

.body-left .sidebar .logo {
  width: 96px;
  height: 32px;
  background-image: url("../assets/img/Logo_Module_TiengViet_White.66947422.svg");
  background-size: 97px;
  background-repeat: no-repeat;
  background-position: center;
  cursor: pointer;
}

.body-left .menu {
  display: flex;
  padding-top: 10px;
  flex-direction: column;
}

.body-left .menu .menu-item {
  display: flex;
  align-items: center;
  cursor: pointer;
  height: 42px;
  border-left: 6px solid transparent;
  padding: 0px 0px 0px 8px;
}

.body-left .menu .menu-item:hover {
  background-color: #616164;
}

.body-left .menu .menu-item .icon {
  width: 24px;
  height: 24px;
  background-repeat: no-repeat;
  background-size: 24px;
  background-position: 18px center;
  margin-right: 8px;
}

.isToggle {
  display: none;
}
</style>
