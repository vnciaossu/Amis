using MISA.AMIS.Core.AttributeCustom;
using System;

namespace MISA.AMIS.Core.Entities
{
    public class Employee : BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>

        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [IsDuplicate]
        [Required()]
        [MaxLength(50, "Mã nhân viên không được quá 50 kí tự")]
        [DisplayName("Mã nhân viên")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ tên
        /// </summary>
        [Required]
        [MaxLength(100, "Tên nhân viên không được quá 100 kí tự")]
        [DisplayName("Tên nhân viên")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính (0-Nữ, 1- Nam, 2- Khác...)
        /// </summary>
        public int? Gender { get; set; }

        public string GenderName
        {
            get
            {
                var name = string.Empty;
                switch (Gender)
                {
                    case (int)Enums.Gender.Female:
                        name = "Nữ";
                        break;

                    case (int)Enums.Gender.Male:
                        name = "Nam";
                        break;

                    case (int)Enums.Gender.Other:
                        name = "Khác";
                        break;

                    default:
                        break;
                }
                return name;
            }
        }

        /// <summary>
        ///  Số CMND/Thẻ căn cước
        /// </summary>
        [IsDuplicate]
        [MaxLength(12, "CMND - Thẻ căn cước không được quá 12 kí tự")]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp CMND
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp CMND
        /// </summary>
        [MaxLength(50, "Địa chỉ không được quá 50 kí tự")]
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Địa chỉ Email
        /// </summary>
        //[IsNotEmail]
        [MaxLength(50, "Email không được quá 50 kí tự")]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [IsDuplicate]
        [MaxLength(20, "Số điện thoại không được quá 20 kí tự")]
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        [IsDuplicate]
        [MaxLength(20, "Số điện thoại không được quá 20 kí tự")]
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// Nhóm chức vụ
        /// </summary>
        public string EmployeePosition { get; set; }

        /// <summary>
        /// Nhóm phòng ban
        /// </summary>
        [Required]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Mã số thuế của cá nhân
        /// </summary>
        [MaxLength(50, "Mã số thuế cá nhân không được quá 50 kí tự")]
        public string PersonalTaxCode { get; set; }

        /// <summary>
        /// Địa chỉ nhân viên
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        [IsDuplicate]
        [MaxLength(20, "Số tài khoản không được quá 20 kí tự")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Tên chi nhánh ngân hàng
        /// </summary>
        public string BankBranchName { get; set; }

        /// <summary>
        /// Tên chi nhánh tỉnh ngân hàng
        /// </summary>
        public string BankProvinceName { get; set; }

        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }

        #endregion Property
    }
}