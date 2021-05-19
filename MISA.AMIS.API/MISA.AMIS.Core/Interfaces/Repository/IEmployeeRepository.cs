using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface EmployeeRepository
    /// </summary>
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Lấy dữ liệu phân trang
        /// </summary>
        /// <param name="pageIndex">Trang </param>
        /// <param name="pageSize">Số bản ghi / trang</param>
        /// <returns>Số lượng bản ghi theo pageSize</returns>
        /// CreatedBy: tmquy (16/05/2021)
        IEnumerable<Employee> GetPaging(int pageIndex, int pageSize);

        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="employeeCode">string: mã nhân viên</param>
        /// <returns>true - nếu đã có; false - nếu chưa có</returns>
        /// CreatedBy: tmquy (16/05/2021)
        bool CheckEmployeeCodeExits(string employeeCode);

        /// <summary>
        /// Kiểm tra phòng ban có tồn tại hay không
        /// </summary>
        /// <param name="departmentId"> id phòng ban</param>
        /// <returns> true nếu tồn tại;false nếu không tồn tại</returns>
        /// CreatedBy: tmquy (16/05/2021)
        bool CheckDepartmentExits(Guid? departmentId);

        /// <summary>
        /// Lấy mã nhân viên mới nhất trong database
        /// </summary>
        /// <returns>mã nhân viên</returns>
        /// CreatedBy: tmquy (16/05/2021)   
        string GetMaxEmployeeCode();


        /// <summary>
        /// Lấy tổng số dữ liệu nhân viên
        /// </summary>
        /// <returns>Tổng bản ghi nhân viên</returns>
        /// CreatedBy: tmquy (16/05/2021) 
        int GetCountEmployee();

        /// <summary>
        /// Lọc nhân viên 
        /// </summary>
        /// <param name="pageIndex">Trang</param>
        /// <param name="pageSize">Số bản ghi / trang</param>
        /// <param name="employeeFilter">keyword để lọc</param>
        /// <returns>entities theo key lọc</returns>
        /// CreatedBy: tmquy (16/05/2021)
        IEnumerable<Employee> GetEmployeeFilter(int pageIndex, int pageSize, string employeeFilter);
    }
}
