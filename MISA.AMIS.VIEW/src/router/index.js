import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

//Views
import EmployeeList from "../views/dictionary/EmployeeList";

const routes = [
  {
    path: "/Employee",
    name: "Employee",
    component: EmployeeList,
  },
];

const router = new VueRouter({
  routes,
});

export default router;
