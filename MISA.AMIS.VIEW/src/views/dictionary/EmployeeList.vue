<template>
  <div class="content">
    <BaseLoading :showLoading="isLoading" />
    <!-- header content -->
    <div class="content__header flex items-center">
      <p class="content__header--title">Nhân viên</p>
      <button class="m-btn" id="btnAdd" @click="onAddEmployee">
        Thêm mới nhân viên
      </button>
    </div>

    <!-- filter -->
    <div class="grid-filter flex items-center sticky-left">
      <div class="search flex items-center">
        <input
          type="text"
          class="m-input"
          placeholder="Tìm theo mã, tên nhân viên"
          @input="filterRecord($event.target.value)"
        />
        <div class="icon-search mi-16"></div>
      </div>
      <button class="reload mi-24" @click="onLoadEmployee"></button>
      <button class="excel mi-24" @click="onBtnClickExportExcel"></button>
    </div>

    <div class="content__grid">
      <table border="0" cellspacing="0" width="100%" id="tblEmployees">
        <thead>
          <th class="td-left-16"></th>
          <th class="sticky-left left-16 justify-center">
            <input
              type="checkbox"
              class="right-5 m-b-5"
              @click="selectAll"
              ref="selectAll"
            />
          </th>
          <th class="sticky-left left-66">Mã nhân viên</th>
          <th>Tên nhân viên</th>
          <th>Giới tính</th>
          <th class="text-center">Ngày sinh</th>
          <th>Số CMND</th>
          <th>Chức danh</th>
          <th>Tên đơn vị</th>
          <th>Số tài khoản</th>
          <th>Tên ngân hàng</th>
          <th>Chi nhánh tk ngân hàng</th>
          <th class="sticky-right text-center">Chức năng</th>
          <th class="td-white-30"></th>
          <th class="td-grey-30"></th>
        </thead>
        <tbody>
          <tr
            v-for="(item, index) in dataEmployee"
            :key="index"
            @dblclick="rowdblClick(item)"
            @click="rowClick(item)"
          >
            <td class="td-left-16"></td>
            <!-- checkbox -->
            <td
              class="sticky-left left-16 justify-center"
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
                rowSelect: item.EmployeeId == isRowSelect,
              }"
            >
              <input
                type="checkbox"
                name=""
                id=""
                class="right-5"
                @click="highlight(item.EmployeeId, $event)"
                :checked="selectedUser.indexOf(item.EmployeeId) != -1"
              />
            </td>

            <!-- Mã NV -->
            <td
              :title="item.EmployeeCode"
              class="sticky-left left-66"
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
                rowSelect: item.EmployeeId == isRowSelect,
              }"
            >
              {{ item.EmployeeCode }}
            </td>

            <!-- Tên NV -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
                rowSelect: item.EmployeeId == isRowSelect,
              }"
            >
              {{ item.EmployeeName }}
            </td>

            <!-- Giới tính -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
                rowSelect: item.EmployeeId == isRowSelect,
              }"
            >
              {{ item.GenderName }}
            </td>

            <!-- Ngày sinh -->
            <td
              class="text-center"
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
                rowSelect: item.EmployeeId == isRowSelect,
              }"
            >
              {{ $fn.fnFormatDate(item.DateOfBirth) }}
            </td>

            <!-- Số CMND -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
                rowSelect: item.EmployeeId == isRowSelect,
              }"
            >
              {{ item.IdentityNumber }}
            </td>

            <!-- Chức danh -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
                rowSelect: item.EmployeeId == isRowSelect,
              }"
            >
              {{ item.EmployeePosition }}
            </td>

            <!-- Tên đơn vị -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
                rowSelect: item.EmployeeId == isRowSelect,
              }"
            ></td>

            <!-- Số tài khoản -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
                rowSelect: item.EmployeeId == isRowSelect,
              }"
            >
              {{ item.BankAccountNumber }}
            </td>

            <!-- Tên ngân hàng -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
                rowSelect: item.EmployeeId == isRowSelect,
              }"
            >
              {{ item.BankName }}
            </td>

            <!-- Chi nhánh tài khoản ngân hàng -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
                rowSelect: item.EmployeeId == isRowSelect,
              }"
            >
              {{ item.BankProvinceName }}
            </td>

            <!--Chức năng -->
            <td
              class="sticky-right flex text-center items-center justify-center"
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
                rowSelect: item.EmployeeId == isRowSelect,
              }"
            >
              <button
                class="btn-edit"
                @click="rowdblClick(item)"
                :class="{
                  selected: selectedUser.indexOf(item.EmployeeId) != -1,
                  rowSelect: item.EmployeeId == isRowSelect,
                }"
              >
                Sửa
              </button>
              <div
                class="button-arrow flex justify-center"
                @click="openContextMenu($event, item)"
              >
                <div class="icon-arrow-up"></div>
              </div>
            </td>
            <td class="td-white-30"></td>
            <td class="td-grey-30"></td>
          </tr>
        </tbody>
      </table>
    </div>

    <div class="no-data" v-if="isNoData">
      <img
        src="https://actappg2.misacdn.net/img/bg_report_nodata.76e50bd8.svg"
        alt=""
        width="132px"
        height="74px"
      />
      <p>Không có dữ liệu</p>
    </div>

    <Pagination
      :total-pages="Math.round(total / pageSize)"
      :total="total"
      :current-page="currentPage"
      v-if="!isNoData"
      @pagechanged="onPageChange"
    />

    <Alert :isShow="isShowAlert" :message="messageAlert" :cls="iconCls">
      <div class="flex w-full justify-between">
        <button class="m-btn-second" @click="onCloseAlert">Không</button>
        <button class="m-btn" @click="onDeleteEmployee">Có</button>
      </div>
    </Alert>

    <EmployeeDetail
      :department="department"
      :title="title"
      @onLoad="onPageChange"
      @onDataSave="onDataEmployeeSave"
      ref="detail"
    />

    <context-menu :display="showContextMenu" ref="menu">
      <ul>
        <li @click="onBtnClickCloned">Nhân bản</li>
        <li @click="openConfirmDelete">Xoá</li>
        <li>Ngưng sử dụng</li>
      </ul>
    </context-menu>
  </div>
</template>

<script>
import axios from "axios";
import Pagination from "../../components/pagination/Pagination";
import EmployeeDetail from "./EmployeeDetail";
import BaseLoading from "../../components/base/BaseLoading";
import ContextMenu from "../../components/base/ContextMenu";
import Alert from "../../components/Alert/Alert";

export default {
  components: {
    EmployeeDetail,
    BaseLoading,
    ContextMenu,
    Alert,
    Pagination,
  },

  computed: {
    /**
     * Lấy kích trước bản ghi trong trang
     * CreatedBy:tmquy(19/05/2021)
     */
    pageSize() {
      return this.$store.getters.getPageSize;
    },
    /**
     * Lấy id dòng đang chọn
     * CreatedBy:tmquy(19/05/2021)
     */
    isRowSelect() {
      return this.$store.getters.getDataRow.EmployeeId;
    },
  },
  data() {
    return {
      API_HOST: this.$Const.API_HOST, //Base api
      isLoading: false, //Hiện thị loading
      showContextMenu: false, //Hiện context menu
      isShowAlert: false, //Hiện alert
      isNoData: false, //Hiện trang no data
      messageAlert: "", //Nội dung alert
      iconCls: "", //Tên class trong alert
      dataEmployee: [], //Các bảng ghi employee
      dataEmployeeSave: [], //Bảng ghi employee khi cất
      selectedUser: [], //Row chọn
      dataContext: {}, //Nội dung của alert <mã nv>
      dataRow: {}, //Dòng employee chọn
      department: [], //Danh sách phòng ban
      title: "", //Nội dung của dialog
      currentPage: 1, //Trang load hiện tại
      total: 0, // Tổng số bản ghi
      timeout: null, //Thời gian chờ
    };
  },
  methods: {
    /**
     * Chuyển sang trang khác
     * @param page trang đich muốn tới
     * CreatedBy:tmquy(17/05/2021)
     */
    onPageChange(page) {
      var pageIndex = page || 1;
      this.currentPage = page;
      this.isLoading = true;
      var url = `${this.API_HOST}/api/v1/Employees/paging?pageIndex=${pageIndex}&pageSize=${this.pageSize}`;
      axios
        .get(url)
        .then((response) => {
          this.dataEmployee = response.data.data;
          this.total = !response.data.Total ? 0 : response.data.Total;
          this.isLoading = false;
          if (this.dataEmployee.length == 0) {
            this.isNoData = true;
          } else {
            this.isNoData = false;
          }
          this.dataRow = {};
        })
        .catch((err) => {
          console.log(err);
        });
    },

    /**
     * Hiện context menu
     * @param e Event
     * @param item dữ liệu nv
     * CreatedBy: tmquy(17/05/2021)
     */
    openContextMenu(e, item) {
      this.dataContext = {};
      this.dataContext = item;
      this.$refs.menu.open(e);
    },

    /**
     * Lấy dữ liệu nhân viên
     * CreatedBy:tmquy(17/05/2021)
     */
    onLoadEmployee() {
      this.onPageChange(1);
    },

    /**
     * Tìm kiếm NV theo mã, tên hoặc sđt
     * @param value giá trị để tìm kiếm
     * CreatedBy:tmquy(17/05/2021)
     */
    filterRecord(value) {
      this.isLoading = true;
      clearTimeout(this.timeOut);
      this.timeOut = setTimeout(() => {
        axios
          .get(
            `${this.API_HOST}/api/v1/Employees/employeeFilter?pageIndex=1&pageSize=${this.pageSize}&employeeFilter=${value}`
          )
          .then((res) => {
            this.dataEmployee = res.data.data;
            this.total = res.data.Total;
            if (this.dataEmployee.length == 0) {
              this.isNoData = true;
            } else {
              this.isNoData = false;
            }
            this.isLoading = false;
          });
      }, 500);
    },

    /**
     * Lấy mã nhân viên mới
     * CreatedBy:tmquy(17/05/2021)
     */
    async genEmployeeCode() {
      let url = this.API_HOST + "/api/v1/Employees/NewEmployeeCode";
      var response = await axios.get(url);
      return response.data;
    },

    /**
     * Hiển thị thêm mới nhân viên
     * CreatedBy:tmquy(17/05/2021)
     */
    async onAddEmployee() {
      if (this.dataEmployeeSave != "") {
        this.dataRow = this.dataEmployeeSave;
        this.$store.commit("setDataRow", this.dataRow);
        this.$store.commit("toggleDialog");
        this.$nextTick(function() {
          this.$refs.detail.$refs.EmployeeCode.focus();
        });
      } else {
        this.dataRow = {};
        this.dataRow.EmployeeCode = await this.genEmployeeCode();
        this.title = "Thêm mới nhân viên";
        this.$store.commit("setDataRow", this.dataRow);
        this.$store.commit("toggleDialog");
        this.$nextTick(function() {
          this.$refs.detail.$refs.EmployeeCode.focus();
        });
      }
    },

    /**
     * Lấy danh sách phòng ban
     * CreatedBy:tmquy(17/05/2021)
     */
    async getDepartment() {
      let url = `${this.API_HOST}/api/v1/Departments`;
      const response = await axios.get(url);
      this.department = response.data;
    },

    /**
     * Hiển thị thông tin nhân viên
     * @param item dữ liệu  của hàng click
     * CreatedBy:tmquy(17/05/2021)
     */
    async rowdblClick(item) {
      var res = await this.onGetEmployeeById(item.EmployeeId);
      if (res.DateOfBirth != null)
        res.DateOfBirth = this.$fn.fnFormatDateInput(res.DateOfBirth);
      if (res.IdentityDate != null)
        res.IdentityDate = this.$fn.fnFormatDateInput(item.IdentityDate);
      this.$store.commit("setDataRow", res);
      this.title = "THÔNG TIN NHÂN VIÊN";
      this.$store.commit("toggleDialog");
      this.$nextTick(function() {
        this.$refs.detail.$refs.EmployeeCode.setAttribute(
          "disabled",
          "disabled"
        );
      });
    },

    /**
     * Highline row chonj
     * @param item dữ liệu của hàng click
     * CreatedBy:tmquy(19/05/2021)
     */
    rowClick(item) {
      this.$store.commit("setDataRow", item);
    },

    /**
     * Lấy thông tin nhân viên bằng id
     * @param id Id NV
     * CreatedBy: tmquy(17/05/2021)
     */
    async onGetEmployeeById(id) {
      const url = `${this.API_HOST}/api/v1/Employees/${id}`;
      const response = await axios.get(url);
      return response.data;
    },

    /**
     * Hiển thị alert xác nhận xoá
     * CreatedBy:tmquy(17/05/2021)
     */
    openConfirmDelete() {
      this.$refs.menu.close();
      this.iconCls = "icon-warning-alert";
      this.messageAlert = `Bạn có thực sự muốn xoá Nhân viên <${this.dataContext.EmployeeCode}> không?`;
      this.isShowAlert = true;
    },

    /**
     * Thực hiện xoá Nhân viên
     * CreatedBy:tmquy(17/05/2021)
     */
    async onDeleteEmployee() {
      var url = `${this.API_HOST}/api/v1/Employees/${this.dataContext.EmployeeId}`;
      await axios.delete(url);
      this.isShowAlert = false;
      this.onPageChange(this.$store.getters.getCurrentPage);
    },

    /**
     * Thay đổi background row
     * @param id Id nhân viên
     * CreatedBy:tmquy(17/05/2021)
     */
    highlight(id) {
      var elIndex = this.selectedUser.indexOf(id);
      var countEmployee = this.dataEmployee.length;
      var countSelectedUser =
        this.selectedUser.indexOf("All") != -1
          ? this.selectedUser.length - 1
          : this.selectedUser.length;
      if (elIndex != -1) {
        this.selectedUser = this.selectedUser.filter(function(e) {
          return e !== id && e != "All";
        });
        this.$refs.selectAll.checked = false;
      } else {
        this.selectedUser.push(id);
        if (countSelectedUser + 1 == countEmployee) {
          this.selectedUser.push("All");
          this.$refs.selectAll.checked = true;
        }
      }
    },

    /**
     * Thay đổi background tất cả row
     * CreatedBy:tmquy(17/05/2021)
     */
    selectAll() {
      if (this.selectedUser.indexOf("All") != -1) {
        this.selectedUser = [];
      } else {
        this.selectedUser = [];
        this.dataEmployee.forEach((element) => {
          this.selectedUser.push(element.EmployeeId);
        });
        this.selectedUser.push("All");
      }
    },
    /**
     * Đóng Alert
     * CreatedBy:tmquy(17/05/2021)
     */
    onCloseAlert() {
      this.isShowAlert = false;
      this.messageAlert = "";
      this.iconCls = "";
    },
    /**
     * Click button xuất excel.
     * CreatedBy: tmquy(17/05/2021)
     */
    onBtnClickExportExcel() {
      window.open(`${this.API_HOST}/api/v1/Employees/Export`, "_blank");
    },
    /**
     * Click nhân bản
     * CreatedBy: tmquy(17/05/2021)
     */
    async onBtnClickCloned() {
      this.$refs.menu.close();
      this.dataContext.EmployeeCode = await this.genEmployeeCode();
      delete this.dataContext.EmployeeId;
      this.$store.commit("setDataRow", this.dataContext);
      this.title = "THÔNG TIN NHÂN VIÊN";
      this.$store.commit("toggleDialog");
    },
    /**
     * Lưu data khi cất
     * CreatedBy: tmquy(17/05/2021)
     */
    onDataEmployeeSave(employee) {
      this.dataEmployeeSave = employee;
    },
  },

  created() {
    this.onLoadEmployee();
    this.getDepartment();
  },
  mounted() {},
};
</script>

<style>
.content {
  overflow: scroll;
  flex-direction: column;
}

.content .content__header {
  justify-content: space-between;
  left: 0;
  width: 100%;
  padding: 15px 0px 15px 0px;
  position: sticky;
  top: 0;
  z-index: 10;
  background-color: #f4f5f6;
}

.content .content__header .content__header--title {
  font-size: 24px;
  font-weight: 700;
}

.content .content__grid {
  min-width: 100%;
  /* height: 100%; */
  background-color: #ffffff;
}

.content .grid-filter {
  justify-content: flex-end;
  padding: 16px 16px 10px;
  background-color: #ffffff;
}

.content .grid-filter .search {
  position: relative;
  width: 250px;
}

.content .grid-filter .search input {
  width: 240px;
}

.content .grid-filter .search .icon-search {
  position: absolute;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -992px -360px;
  cursor: pointer;
  top: 6px;
  left: 87%;
}

.content .grid-filter .reload {
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -423px -201px;
  border: none;
  cursor: pointer;
}

.content .grid-filter .excel {
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -705px -258px;
  border: none;
  cursor: pointer;
  margin: 2px 0 0 10px;
}

.no-data {
  position: sticky;
  bottom: 46;
  z-index: 6;
  background-color: #fff;
  display: flex;
  min-height: 200px;
  flex-direction: column;
  padding-left: 16px;
  padding-right: 30px;
  width: 100%;
  left: 0;
  align-items: center;
  justify-content: center;
}

.no-data p {
  padding: 40px 0 0 0;
}

.content .pagination {
  position: sticky;
  bottom: 0;
  z-index: 6;
  background-color: #fff;
  display: flex;
  min-height: 46px;
  padding-left: 16px;
  padding-right: 30px;
  width: 100%;
  left: 0;
  justify-content: space-between;
}

.content .pagination .select {
  justify-content: space-between;
}

.content .pagination .select select {
  margin: 0 16px;
  width: 200px;
  min-width: 200px;
}

.right-5 {
  right: 5px;
}

.m-dropdown--menu {
  position: absolute;
  background-color: #fff;
}
/*  */
ul {
  width: 125px;
  padding: 5px 0px;
}

ul li {
  list-style: none;
  padding: 5px 10px;
}

ul li:hover {
  background-color: #08bf1e;
  color: white;
}

.button-arrow {
  width: 26px;
  height: 16px;
  cursor: pointer;
}

.btn-edit {
  height: 36px;
  width: 40px;
  background-color: #fff;
  border: none;
  cursor: pointer;
  font-weight: 600;
  color: #005cce;
}

.btn-edit:hover {
  background-color: #f3f8f8;
}
</style>
