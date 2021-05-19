using MISA.AMIS.Core.Enums;
using System;

namespace MISA.AMIS.Core.Entities
{
    public class ServiceResult
    {
        #region Property

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public Object data { get; set; }

        /// <summary>
        /// Message trả về
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// Mã lỗi trả về
        /// </summary>
        public MISACode MISACode { get; set; }

        /// <summary>
        /// Tổng bản ghi
        /// </summary>
        public int? Total { get; set; }

        #endregion Property
    }
}