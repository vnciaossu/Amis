using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Service;
using System;

namespace MISA.AMIS.WebApp.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeController : BaseEntityController<Employee>
    {
        #region Declare
        private IEmployeeService _employeeService;
        #endregion Declare

        #region Constructor
        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion Constructor

        #region Method

        /// <summary>
        /// Phân trang dữ liệu
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// CreatedBy:tmquy (16/05/2021)
        [HttpGet("paging")]
        public IActionResult GetPaging(int pageIndex, int pageSize)
        {
            var entities = _employeeService.GetPaging(pageIndex, pageSize);
            return Ok(entities);
        }

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// CreatedBy:tmquy (16/05/2021)
        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            var entities = _employeeService.GetNewEmployeeCode();
            return Ok(entities);
        }

        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="employeeCode">mã NV</param>
        /// <returns>true nếu đã tồn tại, false nếu chưa tồn tại</returns>
        /// CreatedBy: tmquy (16/05/2021)
        [HttpGet("CheckEmployeeCodeExist")]
        public IActionResult CheckEmployeeCodeExist(string employeeCode)
        {
            var isExist = _employeeService.CheckEmployeeCodeExits(employeeCode);
            return Ok(isExist);
        }

        /// <summary>
        /// Lọc nhân viên
        /// </summary>
        /// <param name="pageIndex">Trang</param>
        /// <param name="pageSize">Số bản ghi / trang</param>
        /// <param name="employeeFilter">keyword</param>
        /// <returns></returns>
        /// CreatedBy: tmquy (16/05/2021)
        [HttpGet("employeeFilter")]
        public IActionResult GetEmployeeFilter(int pageIndex, int pageSize, string employeeFilter)
        {
            var entities = _employeeService.GetEmployeeFilter(pageIndex, pageSize, employeeFilter);
            return Ok(entities);
        }

        /// <summary>
        /// Xuất excel
        /// </summary>   
        /// <returns>
        /// 200 - thành công.
        /// 500 - lỗi server.
        /// </returns>
        /// CreatedBy: tmquy (16/05/2021)
        [HttpGet("Export")]
        public IActionResult Export()
        {
            var stream = _employeeService.ExportExcel();
            string excelName = $"Danh-sach-nhan-vien-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
    #endregion 
}