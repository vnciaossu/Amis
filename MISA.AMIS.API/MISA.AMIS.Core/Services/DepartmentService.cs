using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    public class DepartmentService : BaseService<Department>
    {

        #region contructor
        public DepartmentService(IDepartmentRepository departmentReponsitory) : base(departmentReponsitory)
        {
        }
        #endregion
    }
}
