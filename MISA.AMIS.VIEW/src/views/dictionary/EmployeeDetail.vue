<template>
  <div class="dialog" id="dlgEmployee" v-if="isShow">
    <div
      class="dialog-content"
      ref="modal"
      @mousedown="$fn.startMoving($refs['modal'], 'dlgEmployee', $event)"
      @mouseup="$fn.stopMoving($refs['modal'])"
    >
      <BaseLoading :showLoading="isLoading" class="loading-action" />
      <div class="dialog-header">
        <div class="dialog-title flex items-center">
          {{ title }}
          <div class="ms-checkbox flex items-center">
            <input type="checkbox" name="" id="" />
            <span class="tooltip-content mt-2">Là khách hàng</span>
          </div>

          <div class="ms-checkbox flex item-center mt-4">
            <input type="checkbox" name="" id="" />
            <span class="tooltip-content">Là nhà cung cấp</span>
          </div>
        </div>
        <div class="btn-header flex">
          <div
            class="dialog-help-button"
            @click="onClose"
            title="Trợ giúp"
          ></div>
          <div
            class="dialog-close-button"
            @click="onCloseShowAlert"
            title="Đóng(Esc)"
          ></div>
        </div>
      </div>
      <div class="dialog-body flex flex-column">
        <div class="flex pd-b-12">
          <div class="p-r-26 flex-1">
            <!-- row -->
            <div class="m-row">
              <!-- Mã -->
              <div class="m-item-input w-2/5 p-r-6">
                <label for="EmployeeCode" class="m-label"
                  >Mã<span class="required"> * </span></label
                >
                <input
                  type="text"
                  class="m-input"
                  ref="EmployeeCode"
                  v-model="employee.EmployeeCode"
                  @blur="
                    checkBlankText([
                      { key: 'EmployeeCode', text: 'Mã không được để trống' },
                    ])
                  "
                  tabindex="1"
                />
                <span class="errorCode" :class="{ errorShow: isCodeNull }"
                  >Mã nhân viên không được phép để trống</span
                >
              </div>
              <!-- Tên -->
              <div class="m-item-input w-3/5">
                <label for="" class="m-label"
                  >Tên<span class="required"> * </span></label
                >
                <input
                  type="text"
                  class="m-input"
                  ref="EmployeeName"
                  v-model="employee.EmployeeName"
                  @blur="
                    checkBlankText([
                      { key: 'EmployeeName', text: 'Tên không được để trống' },
                    ])
                  "
                  tabindex="2"
                />
                <span class="errorName" :class="{ errorShow: isNameNull }"
                  >Tên không được phép để trống</span
                >
              </div>
            </div>

            <!-- row -->
            <div class="m-row">
              <!-- Đơn vị -->
              <div class="m-item-input flex-1">
                <label for="" class="m-label"
                  >Đơn vị<span class="required"> * </span></label
                >
                <select
                  class="m-select"
                  v-model="employee.DepartmentId"
                  ref="Department"
                  @blur="
                    checkBlankText([
                      { key: 'Department', text: 'Đơn vị không được để trống' },
                    ])
                  "
                  tabindex="3"
                >
                  <option
                    v-for="(item, index) in department"
                    :value="item.DepartmentId"
                    :key="item.DepartmentId"
                    :selected="index == 1"
                  >
                    {{ item.DepartmentName }}
                  </option>
                </select>
                <span
                  class="errorDepartment"
                  :class="{ errorShow: isDepartmentNull }"
                  >Đơn vị không được phép để trống</span
                >
              </div>
            </div>

            <!-- row -->
            <div class="m-row">
              <!-- Chức danh -->
              <div class="m-item-input flex-1">
                <label for="" class="m-label">Chức danh</label>
                <model-select
                  class="position-select"
                  :options="positions"
                  v-model="employee.EmployeePosition"
                >
                </model-select>
              </div>
            </div>
          </div>

          <div class="flex-1">
            <!-- row -->
            <div class="m-row">
              <!-- Ngày sinh -->
              <div class="m-item-input w-1\/2 p-r-6">
                <label for="" class="m-label">Ngày sinh</label>
                <input
                  type="date"
                  min="1900-01-01"
                  :max="$fn.fnFormatDateInput(new Date())"
                  class="m-input"
                  v-model="employee.DateOfBirth"
                  tabindex="5"
                  placeholder="DD/MM/YYYY"
                />
              </div>
              <!-- Giới tính -->
              <!-- <div class="p-t-5 flex items-center"> -->
              <div class="m-item-input .w-1/2 p-r-6 justify-between">
                <label class="m-label">Giới tính</label>
                <div class="group-gender">
                  <input
                    type="radio"
                    name="gender"
                    value="1"
                    v-model="employee.Gender"
                    class="ml-4"
                    tabindex="6"
                  />
                  <span class="ml-4">Nam</span>
                  <input
                    type="radio"
                    name="gender"
                    value="0"
                    v-model="employee.Gender"
                    class="ml-4"
                    tabindex="7"
                  />
                  <span class="ml-4">Nữ</span>
                  <input
                    type="radio"
                    name="gender"
                    value="2"
                    v-model="employee.Gender"
                    class="ml-4"
                    tabindex="7"
                  />
                  <span class="ml-4">Khác</span>
                </div>
              </div>
              <!-- </div> -->
            </div>

            <!-- row -->
            <div class="m-row">
              <!-- Số CMND -->
              <div class="m-item-input flex-4 p-r-6">
                <label for="" class="m-label">Số CMND</label>
                <input
                  type="text"
                  class="m-input"
                  v-model="employee.IdentityNumber"
                  tabindex="8"
                />
              </div>
              <!-- Ngày cấp -->
              <div class="m-item-input">
                <label for="" class="m-label">Ngày cấp</label>
                <input
                  type="date"
                  min="1900-01-01"
                  :max="$fn.fnFormatDateInput(new Date())"
                  class="m-input"
                  v-model="employee.IdentityDate"
                  tabindex="9"
                />
              </div>
            </div>

            <!-- row -->
            <div class="m-row">
              <!-- Nơi cấp -->
              <div class="m-item-input flex-1">
                <label for="" class="m-label">Nơi cấp</label>
                <input
                  type="text"
                  class="m-input"
                  v-model="employee.IdentityPlace"
                  tabindex="10"
                />
              </div>
            </div>
          </div>
        </div>

        <div class="flex flex-column p-t-10">
          <div class="m-row">
            <!-- Địa chỉ -->
            <div class="m-item-input flex-1">
              <label for="" class="m-label">Địa chỉ</label>
              <input
                type="text"
                class="m-input"
                v-model="employee.Address"
                tabindex="11"
              />
            </div>
          </div>

          <!--row-->
          <div class="m-row">
            <!-- ĐT di động -->
            <div class="m-item-input .w-1/4 p-r-6">
              <label for="" class="m-label">ĐT di động</label>
              <input
                type="text"
                class="m-input"
                v-model="employee.PhoneNumber"
                @keypress="isNumber($event)"
                tabindex="12"
              />
            </div>
            <!-- ĐT cố định -->
            <div class="m-item-input .w-1/4 p-r-6">
              <label for="" class="m-label">ĐT cố định</label>
              <input
                type="text"
                class="m-input"
                v-model="employee.TelephoneNumber"
                tabindex="13"
              />
            </div>
            <!-- Email -->
            <div class="m-item-input .w-1/4 p-r-6">
              <label for="" class="m-label">Email</label>
              <input
                type="text"
                class="m-input"
                v-model="employee.Email"
                ref="Email"
                tabindex="14"
              />
            </div>
          </div>

          <!--row-->
          <div class="m-row">
            <!-- Tài khoản ngân hàng -->
            <div class="m-item-input .w-1/4 p-r-6">
              <label for="" class="m-label">Tài khoản ngân hàng</label>
              <input
                type="text"
                class="m-input"
                v-model="employee.BankAccountNumber"
                tabindex="15"
              />
            </div>
            <!-- Tên ngân hàng -->
            <div class="m-item-input .w-1/4 p-r-6">
              <label for="" class="m-label">Tên ngân hàng</label>
              <input
                type="text"
                class="m-input"
                v-model="employee.BankName"
                tabindex="16"
              />
            </div>
            <!-- Chi nhánh -->
            <div class="m-item-input .w-1/4 p-r-6">
              <label for="" class="m-label">Chi nhánh</label>
              <input
                type="text"
                class="m-input"
                v-model="employee.BankBranchName"
                tabindex="17"
              />
            </div>
          </div>
        </div>

        <div class="dialog-footer flex flex-column">
          <div class="divide"></div>
          <div class="dialog-footer-button flex flex-1">
            <button class="m-btn-second" @click="onClose" tabindex="18">
              Huỷ
            </button>
            <div class="flex">
              <button class="m-btn-second m-r-10" @click="onSave" tabindex="19">
                Cất
              </button>
              <button class="m-btn" @click="onSaveAndNew" tabindex="20">
                Cất và thêm
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <!--  -->
    <Alert :isShow="isShowAlert" :message="messageAlert" :cls="iconCls">
      <div v-if="iconCls == 'icon-error'" class="flex w-full justify-center ">
        <button class="m-btn" @click="onCloseAlert">Đóng</button>
      </div>
      <div
        v-if="iconCls == 'icon-error-exits'"
        class="flex w-full justify-right "
      >
        <button class="m-btn" @click="onCloseAlert">Đồng ý</button>
      </div>
      <div v-if="iconCls == 'icon-change'" class="flex w-full justify-between">
        <button
          class="m-btn"
          style="background-color: white; color: black;  border: 1px solid black;font-weight: 700"
          @click="onCloseAlert"
        >
          Hủy
        </button>
        <div class="flex w-full justify-right">
          <button
            class="m-btn"
            style="margin-right: 10px; background-color: white; color: black; border: 1px solid black;font-weight: 700"
            @click="onCloseAndClear"
          >
            Không
          </button>
          <button class="m-btn" @click="onSave">Có</button>
        </div>
      </div>
    </Alert>
    <!--  -->
  </div>
</template>

<script>
import axios from "axios";
import Alert from "../../components/Alert/Alert";
import { ModelSelect } from "vue-search-select";
import BaseLoading from "../../components/base/BaseLoading";
import Vue from "vue";

export default {
  name: "Detail",
  components: {
    Alert,
    BaseLoading,
    ModelSelect,
  },
  props: ["department", "title", "dataEmployeeSave"],
  watch: {
    /**
     * Focus vào employeecode khi hiện
     * CreatedBy:tmquy(19/05/2021)
     */
    show: function() {
      if (this.isShow) {
        Vue.nextTick().then(function() {
          this.$refs.EmployeeCode.focus();
        });
      }
    },
  },
  computed: {
    /**
     * Hiển thị dialog
     * CreatedBy:tmquy(19/05/2021)
     */
    isShow() {
      return this.$store.getters.getIsShow;
    },
    /**
     * Lấy nhân viên được chọn
     * CreatedBy:tmquy(19/05/2021)
     */
    employee() {
      return this.$store.getters.getDataRow;
    },
  },
  data() {
    return {
      isShowAlert: false, //Hiện thị alert
      messageAlert: "", // Nội dung hiện thị của alert
      iconCls: "", //Class icon của alert
      API_HOST: this.$Const.API_HOST, // Base API
      isOnlySave: false, //Trạng thái cất hoặc cất và thêm
      isLoading: false, //Hiện thị loading
      positions: [
        //Vị trí
        { value: "Giám đốc", text: "Giám đốc" },
        { value: "Nhân viên thực tập", text: "Nhân viên thực tập" },
        { value: "Nhân viên chính thức", text: "Nhân viên chính thức" },
        { value: "Lễ tân", text: "Lễ tân" },
        { value: "Thực tập sinh", text: "Thực tập sinh" },
        { value: "Trưởng phòng", text: "Trưởng phòng" },
      ],
      isNameNull: false, //Kiểm tra tên trống
      isCodeNull: false, //Kiểm tra code trống
      isDepartmentNull: false, //Kiểm tra phòng ban trống
    };
  },
  methods: {
    /**
     * Load lại dữ liệu
     * CreatedBy: tmquy(17/05/2021)
     * */
    onLoadEmployee() {
      this.$emit("onLoad", this.$store.getters.getCurrentPage);
    },
    /**
     * Lưu thông tin (Cất dữ liệu)
     * CreatedBy: tmquy(17/05/2021)
     * */
    onSave() {
      //Validate
      this.messageAlert = "";
      this.validateToSave();
      if (!this.employee.EmployeeId) {
        this.checkEmployeeCodeExist(this.employee.EmployeeCode);
        this.isLoading = false;
      }

      //Lưu dữ liệu vào onDataSave EmployeeList
      if (this.messageAlert == "") {
        this.$emit("onDataSave", this.employee);
        this.isOnlySave = true;
        this.onClose();
      }
    },

    /**
     * Lưu và thêm mới
     * CreatedBy: tmquy(17/05/2021)
     * */
    onSaveAndNew() {
      this.isLoading = true;
      this.isOnlySave = false;
      this.fnSave();
    },

    /**
     * Thực hiện lưu thông tin
     * CreatedBy: tmquy(17/05/2021)
     * */
    async fnSave() {
      this.$emit("onDataSave", []);
      // var countErr = 0;
      var url = "";
      //Validate
      this.validateToSave();
      if (!this.employee.EmployeeId) {
        await this.checkEmployeeCodeExist(this.employee.EmployeeCode);
        this.isLoading = false;
      }

      // lưu thông tin
      if (this.employee.EmployeeId) {
        //cập nhật
        url = `${this.API_HOST}/api/v1/Employees?entityId=${this.employee.EmployeeId}`;
        await axios.put(url, this.employee);
        this.onClose();
        this.onLoadEmployee();
        this.isLoading = false;
      } else {
        //Thêm mới
        url = `${this.API_HOST}/api/v1/Employees`;
        await axios.post(url, this.employee);
        this.onClose();
        this.onLoadEmployee();
        this.isLoading = false;
      }
    },

    /**
     * Chỉ cho phép nhập số
     * CreateBy:tmquy(17/05/2021)
     */
    isNumber: function(evt) {
      evt = evt ? evt : window.event;
      var charCode = evt.which ? evt.which : evt.keyCode;
      if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        evt.preventDefault();
      } else {
        return true;
      }
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
     * Validate dữ liệu để lưu vào Database
     * CreateBy:tmquy(17/05/2021)
     */
    validateToSave() {
      //kiểm tra các trường rỗng
      var obj = [
        {
          key: "EmployeeName",
          text: "Tên không được để trống",
        },
        {
          key: "EmployeeCode",
          text: "Mã NV không được để trống",
        },
        {
          key: "Department",
          text: "Đơn vị không được để trống",
        },
      ];
      this.checkBlankText(obj);
      //kiểm tra giá trị email hợp lệ
      this.checkEmailValid();
      if (this.messageAlert != "") {
        this.iconCls = "icon-error";
        if (this.isLoading) this.isLoading = false;
        this.isShowAlert = true;
      }
    },

    /**
     * Check email validate
     * CreatedBy:tmquy(17/05/2021)
     */
    checkEmailValid() {
      var email = this.$refs["Email"].value;
      if (!this.$fn.validateEmail(email) && email != "") {
        this.$refs["Email"].classList.add("isValid");
        this.$refs["Email"].setAttribute("title", "Email không đúng định dạng");
        this.messageAlert +=
          this.messageAlert == "" ? "Email không đúng định dạng" : "";
        this.$refs["Email"].focus();
      } else if (email != "") {
        this.$refs["Email"].classList.remove("isValid");
        this.$refs["Email"].setAttribute("title", "");
      }
    },

    /**
     * Validate Blank
     * @param obj danh sách các trường muốn kiểm tra
     * CreateBy:tmquy(17/05/2021)
     */
    checkBlankText(obj) {
      obj.forEach((element) => {
        if (this.$refs[element.key].value == "") {
          this.$refs[element.key].classList.add("isValid");
          this.$refs[element.key].setAttribute("title", element.text);
          this.messageAlert += this.messageAlert == "" ? element.text : "";
          if (element.key == "EmployeeCode") {
            this.isCodeNull = true;
          } else if (element.key == "EmployeeName") {
            this.isNameNull = true;
          } else if (element.key == "Department") {
            this.isDepartmentNull = true;
          }
        } else {
          this.$refs[element.key].classList.remove("isValid");
          this.$refs[element.key].setAttribute("title", "");
          this.isCodeNull = false;
          this.isNameNull = false;
          this.isDepartmentNull = false;
        }
      });
    },

    /**
     * Kiểm tra mã nhân viên đã tồn tại hay chưa
     * @param employeeCode Mã nhân viên
     * CreatedBy: tmquy(17/05/2021)
     */
    async checkEmployeeCodeExist(employeeCode) {
      var url = `${this.API_HOST}/api/v1/Employees/CheckEmployeeCodeExist?employeeCode=${employeeCode}`;
      var res = await axios.get(url);
      if (res.data) {
        this.messageAlert +=
          this.messageAlert == ""
            ? `Mã nhân viên <${employeeCode}> đã tồn tại trong hệ thống, vui lòng kiểm tra lại`
            : "";
        this.iconCls = "icon-error-exits";
        this.isShowAlert = true;
      }
    },

    /**
     * Đóng alert
     * CreatedBy: tmquy(17/05/2021)
     */
    onCloseAlert() {
      this.isShowAlert = false;
      this.messageAlert = "";
      this.iconCls = "";
    },

    /**
     * Đóng form
     * CreatedBy:tmquy(17/05/2021)
     */
    onClose() {
      this.$store.commit("toggleDialog");
      this.onLoadEmployee();
      this.onCloseAlert();
    },

    /**
     * Đóng form và xóa
     * CreatedBy:tmquy(18/05/2021)
     */
    onCloseAndClear() {
      this.$emit("onDataSave", []);
      this.onClose();
    },
    /**
     * Hiện alert khi ấn close
     * CreatedBy:tmquy(18/05/2021)
     */
    onCloseShowAlert() {
      if (
        this.employee.EmployeeName != null ||
        this.employee.DepartmentId != null
      ) {
        this.isShowAlert = true;
        this.messageAlert = "Dữ liệu đã bị thay đổi. Bạn có muốn cất không?";
        this.iconCls = "icon-change";
      } else {
        this.$store.commit("toggleDialog");
        this.onCloseAlert();
      }
    },
  },
  created() {},
  mounted() {
    if (this.$refs.EmployeeCode) {
      this.$refs.EmployeeCode.focus();
    }
  },
};
</script>

<style></style>
