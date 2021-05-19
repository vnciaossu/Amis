using System;

namespace MISA.AMIS.Core.Entities
{
    public class Department : BaseEntity
    {
        #region Property

        /// <summary>
        /// id phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        #endregion Property
    }
}