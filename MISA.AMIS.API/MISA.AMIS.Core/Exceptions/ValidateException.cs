using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Exceptions
{
    public class ValidateExceptions:Exception
    {
        
        /// <summary>
        /// Xử lý ngoại lệ
        /// </summary>
        /// <param name="msg">Thông tin báo lỗi</param>
        /// <param name="data">Dữ liệu</param>
        /// Created by: TMQUY (17/05/2021)
        public ValidateExceptions(string msg, object data = null) : base(msg, new Exception())
        {
            
        }
    }
}
