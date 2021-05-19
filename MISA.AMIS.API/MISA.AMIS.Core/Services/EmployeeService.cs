using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces.Repository;
using MISA.AMIS.Core.Interfaces.Service;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace MISA.AMIS.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Declare

        private IEmployeeRepository _employeeReponsitory;
        private ServiceResult _serviceResult;

        #endregion Declare

        #region Constructor

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeReponsitory = employeeRepository;
            _serviceResult = new ServiceResult();
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="employeeCode">mã nhân viên</param>
        /// <returns>
        /// true: đã tồn tại
        /// false: chưa tồn tại
        /// </returns>
        /// Created by: tmquy (16/05/2021)
        public bool CheckEmployeeCodeExits(string employeeCode)
        {
            var isExist = _employeeReponsitory.CheckEmployeeCodeExits(employeeCode);
            return isExist;
        }

        /// <summary>
        /// Export file excel danh sách nhân viên
        /// </summary>
        /// <param name="employeeFilter">Bộ lọc</param>
        /// <returns>Stream</returns>
        /// CreatedBy: tmquy (16/05/2021)
        public Stream ExportExcel()
        {
            var res = _employeeReponsitory.GetEntities();
            var list = res.ToList();
            var stream = new MemoryStream();
            using var package = new ExcelPackage(stream);
            var workSheet = package.Workbook.Worksheets.Add("DANH SÁCH NHÂN VIÊN");

            // set độ rộng col
            workSheet.Column(1).Width = 5;
            workSheet.Column(2).Width = 15;
            workSheet.Column(3).Width = 30;
            workSheet.Column(4).Width = 10;
            workSheet.Column(5).Width = 15;
            workSheet.Column(6).Width = 30;
            workSheet.Column(7).Width = 30;
            workSheet.Column(8).Width = 15;
            workSheet.Column(9).Width = 30;

            using (var range = workSheet.Cells["A1:I1"])
            {
                range.Merge = true;
                range.Value = "DANH SÁCH NHÂN VIÊN";
                range.Style.Font.Bold = true;
                range.Style.Font.Size = 16;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            // style cho excel.
            workSheet.Cells[3, 1].Value = "STT";
            workSheet.Cells[3, 2].Value = "Mã nhân viên";
            workSheet.Cells[3, 3].Value = "Tên nhân viên";
            workSheet.Cells[3, 4].Value = "Giới tính";
            workSheet.Cells[3, 5].Value = "Ngày sinh";
            workSheet.Cells[3, 6].Value = "Chức danh";
            workSheet.Cells[3, 7].Value = "Tên đơn vị";
            workSheet.Cells[3, 8].Value = "Số tài khoản";
            workSheet.Cells[3, 9].Value = "Tên ngân hàng";

            using (var range = workSheet.Cells["A3:I3"])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                range.Style.Font.Bold = true;
                range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            int i = 0;
            // đổ dữ liệu từ list vào.
            foreach (var e in list)
            {
                workSheet.Cells[i + 4, 1].Value = i + 1;
                workSheet.Cells[i + 4, 2].Value = e.EmployeeCode;
                workSheet.Cells[i + 4, 3].Value = e.EmployeeName;
                workSheet.Cells[i + 4, 4].Value = e.GenderName;
                workSheet.Cells[i + 4, 5].Value = e.DateOfBirth?.ToString("dd/MM/yyyy");
                workSheet.Cells[i + 4, 6].Value = e.EmployeePosition;
                workSheet.Cells[i + 4, 7].Value = e.DepartmentName;
                workSheet.Cells[i + 4, 8].Value = e.BankAccountNumber;
                workSheet.Cells[i + 4, 9].Value = e.BankName;

                using (var range = workSheet.Cells[i + 4, 1, i + 4, 9])
                {
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }
                i++;
            }

            package.Save();
            stream.Position = 0;
            return package.Stream;
        }

        /// <summary>
        /// Lấy tổng số bản ghi
        /// </summary>
        /// <returns>
        /// Sô lượng bản ghi
        /// </returns>
        /// Created by: tmquy (16/05/2021)
        public int GetCountEmployee()
        {
            var count = _employeeReponsitory.GetCountEmployee();
            return count;
        }

        /// <summary>
        /// Lấy nhân viên theo tiêu chí
        /// </summary>
        /// <param name="pageIndex">trang</param>
        /// <param name="pageSize">số lượng bản ghi</param>
        /// <param name="employeeFilter">lọc</param>
        /// <returns>Nhân viên</returns>
        /// Created by: tmquy (16/05/2021)
        public ServiceResult GetEmployeeFilter(int pageIndex, int pageSize, string employeeFilter)
        {
            var count = _employeeReponsitory.GetCountEmployee();
            var entities = _employeeReponsitory.GetEmployeeFilter(pageIndex, pageSize, employeeFilter);
            _serviceResult.data = entities;
            _serviceResult.Total = count;
            return _serviceResult;
        }

        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên mới nhất</returns>
        /// Created by: tmquy (16/05/2021)
        public string GetNewEmployeeCode()
        {
            var code = _employeeReponsitory.GetMaxEmployeeCode();
            string letters = string.Empty;
            string numbers = string.Empty;

            foreach (char c in code)
            {
                if (Char.IsLetter(c))
                {
                    letters += c;
                }
                if (Char.IsNumber(c))
                {
                    numbers += c;
                }
            }
            var newCode = $"{letters}-{Int32.Parse(numbers) + 1}";
            return newCode;
        }

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="pageIndex">trang</param>
        /// <param name="pageSize">số lượng bản ghi</param>
        /// <returns>Nhân viên</returns>
        /// Created by: tmquy (16/05/2021)
        public ServiceResult GetPaging(int pageIndex, int pageSize)
        {
            var count = _employeeReponsitory.GetCountEmployee();
            var entities = _employeeReponsitory.GetPaging(pageIndex, pageSize);
            _serviceResult.data = entities;
            _serviceResult.Total = count;
            return _serviceResult;
        }

        /// <summary>
        /// Kiểm tra dữ liệu
        /// </summary>
        /// <param name="employee"></param>
        /// Created by: tmquy (16/05/2021)
        protected override void ValidateCustom(Employee employee)
        {
            //Check phòng ban có tồn tại hay không
            if (!string.IsNullOrEmpty(employee.DepartmentId.ToString()))
            {
                var res = _employeeReponsitory.CheckDepartmentExits(employee.DepartmentId);
                if (!res)
                {
                    throw new ValidateExceptions("Thông tin phòng ban không tồn tại trong hệ thống");
                }
            }
        }
    }

    #endregion Method
}