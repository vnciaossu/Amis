using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Service
{
    public interface IEmployeeService: IBaseService<Employee>
    {
        /// <summary>
        /// Phân trang dữ liệu
        /// </summary>
        /// <param name="pageIndex">Trang hiện tại</param>
        /// <param name="pageSize">số bản ghi trên 1 trang</param>
        /// <returns></returns>
        /// CreatedBy:tmquy (16/05/2021)
        ServiceResult GetPaging(int pageIndex, int pageSize);

        /// <summary>
        /// Lấy mã nhân viên mới nhất
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:tmquy (16/05/2021)
        string GetNewEmployeeCode();

        /// <summary>
        /// Kieemr tra max nhaan vieen
        /// </summary>
        /// <param name="employeeCode">string: mã nhân viên</param>
        /// <returns>true - nếu đã có; false - nếu chưa có</returns>
        /// CreatedBy: tmquy (16/05/2021)
        bool CheckEmployeeCodeExits(string employeeCode);

        /// <summary>
        /// Tổng số dữ liệu trong db
        /// </summary>
        /// <returns>Tổng số dữ liệu</returns>
        /// CreatedBy: tmquy (16/05/2021)
        int GetCountEmployee();

        /// <summary>
        /// Tìm kiếm nhân viên
        /// </summary>
        /// <param name="pageIndex">Trang</param>
        /// <param name="pageSize">Số bản ghi / trang</param>
        /// <param name="employeeFilter">keyword cần lọc</param>
        /// <returns></returns>
        /// CreatedBy: tmquy (16/05/2021)
        ServiceResult GetEmployeeFilter(int pageIndex, int pageSize, string employeeFilter);

        /// <summary>
        /// Export file excel danh sách nhân viên có bộ lọc
        /// </summary>
        /// <param name="employeeFilter">Bộ lọc</param>
        /// <returns>Stream</returns>
        /// CreatedBy: tmquy (16/05/2021)
        public Stream ExportExcel();
    }
}
