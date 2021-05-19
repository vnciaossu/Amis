import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import { func } from "./common/js/mUtils.js";
import { Const } from "./common/js/mConsts.js";

export const EventBus = new Vue();

Vue.prototype.$fn = func;
Vue.prototype.$Const = Const;

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
