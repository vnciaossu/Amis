using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface base repository
    /// </summary>
    /// <typeparam name="MISAEntity">Kiểu của thực thể</typeparam>
    /// CreatedBy:tmquy (16/05/2021)
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <returns></returns>
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
        int Insert(MISAEntity entity);

        /// <summary>
        /// Cập nhật thông tin thực thể
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <param name="entityId">Id thực thể</param>
        /// <returns>Số bản ghi được update trong db</returns>
        /// CreatedBy:tmquy (16/05/2021)
        int Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xoá thực thể
        /// </summary>
        /// <param name="entityId">Id thực thể</param>
        /// <returns>Số bản ghi đã xoá tỏng db</returns>
        /// CreatedBy:tmquy (16/05/2021)
        int Delete(Guid entityId);

        /// <summary>
        /// Lấy trường dữ liệu của entity
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="property">trường dữ liệu</param>
        /// <returns>property</returns>
        /// CreatedBy: tmquy (16/05/2021)
        MISAEntity GetEntityByProperty(MISAEntity entity, PropertyInfo property);
    }
}
