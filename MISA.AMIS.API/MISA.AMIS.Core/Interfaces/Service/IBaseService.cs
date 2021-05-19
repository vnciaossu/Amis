using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Service
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <returns>Toàn bộ entities trong bảng</returns>
        /// CreatedBy:tmquy (16/05/2021)
        IEnumerable<MISAEntity> GetEntities();

        /// <summary>
        /// Lấy thông tin của thực thể theo Id
        /// </summary>
        /// <param name="entityId">Id thực thể</param>
        /// <returns>Thực thể có id tương ứng</returns>
        /// CreatedBy:tmquy (16/05/2021)
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <returns>Số bản ghi thêm mới bản db</returns>
        /// CreatedBy:tmquy (16/05/2021)
        ServiceResult Insert(MISAEntity entity);

        /// <summary>
        /// Cập nhật thông tin thực thể
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <param name="entityId">Id thực thể</param>
        /// <returns>Số bản ghi được update trong db</returns>
        /// CreatedBy:tmquy (16/05/2021)
        ServiceResult Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xoá thực thể
        /// </summary>
        /// <param name="entityId">Id thực thể</param>
        /// <returns>Số bản ghi đã xoá trong db</returns>
        /// CreatedBy:tmquy (16/05/2021)
        ServiceResult Delete(Guid entityId);
    }
}
