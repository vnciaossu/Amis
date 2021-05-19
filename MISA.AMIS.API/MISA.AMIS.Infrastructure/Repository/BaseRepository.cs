using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Enums;
using MISA.AMIS.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace MISA.AMIS.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity : BaseEntity
    {
        #region Declare

        private IConfiguration _configuration;
        protected string _tableName = string.Empty;
        protected string _connectingDB;
        protected IDbConnection _dbConnection;

        #endregion Declare

        #region Constructor

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _tableName = typeof(MISAEntity).Name;
            _connectingDB = configuration.GetConnectionString("connectionDB");
            _dbConnection = new MySqlConnection(_connectingDB);
        }

        #endregion Constructor

        #region Property

        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns>bản ghi</returns>
        /// Created by: tmquy (16/05/2021)
        public IEnumerable<MISAEntity> GetEntities()
        {
            //get data
            var entities = _dbConnection.Query<MISAEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="entityId">id entity</param>
        /// <returns>bản ghi theo id</returns>
        /// Created by: tmquy (16/05/2021)
        public MISAEntity GetById(Guid entityId)
        {
            var sqlCommand = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByIdInputParamName = $"@{_tableName}Id";
            dynamicParameters.Add(storeGetByIdInputParamName, entityId.ToString());

            var entity = _dbConnection.Query<MISAEntity>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// 1: thêm thành công
        /// 0: không thêm được
        /// </returns>
        /// Created by: tmquy (16/05/2021)
        public int Insert(MISAEntity entity)
        {
            var sqlCommand = $"Proc_Insert{_tableName}";
            var rowAffects = _dbConnection.Execute(sqlCommand, param: entity, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// Created by: tmquy (16/05/2021)
        public int Update(MISAEntity entity, Guid entityId)
        {
            var sqlCommand = $"Proc_Update{_tableName}";
            var rowAffects = _dbConnection.Execute(sqlCommand, entity, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// Created by: tmquy (16/05/2021)
        public int Delete(Guid entityId)
        {
            var result = _dbConnection.Execute($"DELETE FROM {_tableName} WHERE {_tableName}Id = '{entityId}'", commandType: CommandType.Text);
            return result;
        }

        /// <summary>
        /// Lấy entity để kiểm tra trùng hay không
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        /// Created by: tmquy (16/05/2021)
        public MISAEntity GetEntityByProperty(MISAEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if (entity.EntityState == EntityState.AddNew)
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
            else if (entity.EntityState == EntityState.Update)
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}' AND {_tableName}Id <> '{keyValue}'";
            else
                return null;
            var entityReturn = _dbConnection.Query<MISAEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entityReturn;
        }

        #endregion Property
    }
}