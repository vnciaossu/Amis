using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.WebApp.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class DepartmentController : BaseEntityController<Department>
    {
        public DepartmentController(IBaseService<Department> baseService) : base(baseService)
        {

        }
    }
}
