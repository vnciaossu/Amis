using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Declare

        #endregion

        #region Constructor
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion

        #region Property
        /// <summary>
        /// Kiểm tra mã đơn vị
        /// </summary>
        /// <param name="departmentId">mã đơn vị</param>
        /// <returns></returns>
        /// Created by: tmquy (16/05/2021)
        public bool CheckDepartmentExits(Guid? departmentId)
        {
            var storeName = $"Proc_CheckDepartmentExist";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@departmentId", departmentId.ToString());

            var res = _dbConnection.QueryFirstOrDefault<bool>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return res;
        }
        /// <summary>
        /// Kiểm tra mã nhân viên
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        /// Created by: tmquy (16/05/2021)
        public bool CheckEmployeeCodeExits(string employeeCode)
        {
            var storeName = $"Proc_Check{_tableName}CodeExist";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeCode", employeeCode);

            var res = _dbConnection.QueryFirstOrDefault<bool>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return res;
        }
        /// <summary>
        /// Lấy tổng số nhân viên
        /// </summary>
        /// <returns></returns>
        /// Created by: tmquy (16/05/2021)
        public int GetCountEmployee()
        {
            var storeName = $"Proc_GetCountEmployee";
            var res = _dbConnection.QueryFirstOrDefault<int>(storeName, commandType: CommandType.StoredProcedure);
            return res;
        }
        /// <summary>
        /// Lọc nhân viên theo tiêu chí
        /// </summary>
        /// <param name="pageIndex">bản ghi</param>
        /// <param name="pageSize">số lượng bản ghi</param>
        /// <param name="employeeFilter">tiêu chí</param>
        /// <returns></returns>
        /// Created by: tmquy (16/05/2021)
        public IEnumerable<Employee> GetEmployeeFilter(int pageIndex, int pageSize, string employeeFilter)
        {
            var storeName = $"Proc_EmployeeFilter";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@pageIndex", pageIndex);
            dynamicParameters.Add($"@pageSize", pageSize);
            dynamicParameters.Add($"@employeeFilter", employeeFilter);
            var entity = _dbConnection.Query<Employee>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        /// <summary>
        /// Lấy mã nhân viên mới nhất
        /// </summary>
        /// <returns></returns>
        /// Created by: tmquy (16/05/2021)
        public string GetMaxEmployeeCode()
        {
            var storeName = $"Proc_GetMaxEmployeeCode";
            var res = _dbConnection.QueryFirstOrDefault<string>(storeName, commandType: CommandType.StoredProcedure);
            return res;
        }
        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="pageIndex">bản ghi</param>
        /// <param name="pageSize">số lượng bản ghi</param>
        /// <returns></returns>
        /// Created by: tmquy (16/05/2021)
        public IEnumerable<Employee> GetPaging(int pageIndex, int pageSize)
        {
            var storeName = $"Proc_Get{_tableName}Paging";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@pageIndex", pageIndex);
            dynamicParameters.Add($"@pageSize", pageSize);

            var entity = _dbConnection.Query<Employee>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        #endregion
    }
}
