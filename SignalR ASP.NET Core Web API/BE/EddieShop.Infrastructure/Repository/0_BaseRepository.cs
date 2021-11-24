using Dapper;
using EddieShop.Core.Interfaces.Base;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using static EddieShop.Core.Attributes.EddieShopAttributes;

namespace EddieShop.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        #region DECLARE
        protected IConfiguration _configuration;
        protected IDbConnection _dbConnection;
        protected string _connectionString = string.Empty;
        private string _className;

        #endregion

        #region CONSTRUCTOR
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("EddieShopConnection");
            _className = typeof(TEntity).Name;
        }
        #endregion

        #region METHOD
        #region GetAll
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>  
        /// CreatedBy: NTDUNG(17/8/2021)
        /// ModifiedBy: NTDUNG(17/8/2021)
        public IEnumerable<TEntity> GetAllEntities()
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var sqlCommand = $"SELECT * from {_className} ORDER BY CreatedDate DESC";
                var entities = _dbConnection.Query<TEntity>(sqlCommand);
                return entities;

            }

        }
        #endregion

        #region GetByID
        /// <summary>
        /// Lấy thông tin theo Id
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(17/8/2021)
        /// ModifiedBy: NTDUNG(17/8/2021) 
        public virtual TEntity GetEntityById(Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var sqlCommand = $"SELECT * from {_className} WHERE {_className}ID = @{_className}ID";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{_className}ID", entityId);
                var entity = _dbConnection.QueryFirstOrDefault<TEntity>(sqlCommand, param: dynamicParameters);
                return entity;
            }
        }
        #endregion

        #region GetByProperties
        /// <summary>
        /// Lấy thông tin theo property
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(23/11/2021)
        public TEntity GetEntityByProperties(object columnsGet)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            { 
                var queryLine = new List<string>();
                DynamicParameters dynamicParameters = new DynamicParameters();
                var properties = columnsGet.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var propValue = property.GetValue(columnsGet); 

                    queryLine.Add($"{propName} = @{propName}");
                    dynamicParameters.Add($"@{propName}", propValue);
                }

                var sqlCommand = $"SELECT * FROM {_className} WHERE {String.Join(" AND ", queryLine.ToArray())} ";
                var entity = _dbConnection.QueryFirstOrDefault<TEntity>(sqlCommand, param: dynamicParameters);
                return entity;
            }
        }
        #endregion

        #region GetByValueColumns
        /// <summary>
        /// Lấy thông tin theo các cột có giá trị
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(23/11/2021)
        public List<TEntity> GetByValueColumns(TEntity columnsGet)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var queryLine = new List<string>();
                DynamicParameters dynamicParameters = new DynamicParameters();
                var properties = columnsGet.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var propValue = property.GetValue(columnsGet, null);
                    if (propValue != null)
                    {
                        queryLine.Add($"{propName} = @{propName}");
                        dynamicParameters.Add($"@{propName}", propValue);
                    }
                }

                var sqlCommand = $"SELECT * FROM {_className} WHERE {String.Join(" AND ", queryLine.ToArray())} ";
                var entity = _dbConnection.Query<TEntity>(sqlCommand, param: dynamicParameters);
                return entity.ToList();
            }
        }
        #endregion

        #region GetByIds
        /// <summary>
        /// Lấy theo các id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (24/11/2021)
        public List<TEntity> GetByIds(List<Guid> ids)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                var listIds = ids.Select(id => $"'{id}'").ToList();
                var sqlCommand = $"SELECT * FROM {_className} WHERE {_className}ID IN ({String.Join(", ", listIds)})";
                var entity = _dbConnection.Query<TEntity>(sqlCommand, param: dynamicParameters);
                return entity.ToList();
            }
        }
        #endregion

        #region Insert
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thông tin được thêm</param>
        /// <returns>số bản ghi được thêm</returns>
        /// CreatedBy: NTDUNG(17/8/2021)
        /// ModifiedBy: NTDUNG(17/8/2021)
        public int Insert(TEntity entity)
        {
            MySqlConnection mySqlConnection = null;
            IDbTransaction transaction = null;
            var rowEffects = -1;

            try
            {
                mySqlConnection = new MySqlConnection(_connectionString);
                mySqlConnection.Open();
                transaction = mySqlConnection.BeginTransaction();

                var columnsName = new List<string>();
                var columnsParam = new List<string>();
                DynamicParameters dynamicParameters = new DynamicParameters();
                var properties = entity.GetType().GetProperties();
                foreach (var property in properties)
                {
                    if (property.IsDefined(typeof(EddieNotMap), false)) continue;
                    var propName = property.Name;
                    var propValue = property.GetValue(entity);
                    // Gán Id mới
                    if (propName.Equals($"{_className}ID") && property.PropertyType == typeof(Guid))
                    {
                        propValue = Guid.NewGuid();
                    }
                    // Bổ sung ngày tạo mới
                    if (propName == "CreatedDate")
                    {
                        propValue = DateTime.Now;
                    }

                    columnsName.Add(propName);
                    columnsParam.Add($"@{propName}");
                    dynamicParameters.Add($"@{propName}", propValue);

                }
                var sqlQuery = $"INSERT INTO {_className} ({String.Join(", ", columnsName.ToArray())}) " +
                            $"VALUES({String.Join(", ", columnsParam.ToArray())})";
                rowEffects = mySqlConnection.Execute(sqlQuery, param: dynamicParameters, transaction: transaction);

                transaction.Commit();
            }
            catch(Exception)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw;
            }
            finally
            {
                if (mySqlConnection != null) mySqlConnection.Close();
            }
            return rowEffects;
        }
        #endregion

        #region Update
        /// <summary>
        /// Sửa thông tin
        /// </summary>
        /// <param name="entity">Thông tin cần sửa</param>
        /// <param name="entityId">Id </param>
        /// <returns>số bản ghi được sửa</returns>
        /// CreatedBy: NTDUNG(17/8/2021)
        /// ModifiedBy: NTDUNG(17/8/2021)
        public int Update(TEntity entity, Guid entityId)
        {
            MySqlConnection mySqlConnection = null;
            IDbTransaction transaction = null;
            var rowEffects = -1;

            try
            {
                mySqlConnection = new MySqlConnection(_connectionString);
                mySqlConnection.Open();
                transaction = mySqlConnection.BeginTransaction();

                var queryLine = new List<string>();
                DynamicParameters dynamicParameters = new DynamicParameters();
                var properties = entity.GetType().GetProperties();
                foreach (var property in properties)
                {
                    if (property.IsDefined(typeof(EddieNotMap), false)) continue;
                    var propName = property.Name;
                    var propValue = property.GetValue(entity);
                    // Gán Id cũ
                    if (propName.Equals($"{_className}ID") && property.PropertyType == typeof(Guid))
                    {
                        propValue = entityId;
                    }
                    // Bổ sung ngày chỉnh sửa
                    if (propName == "ModifiedDate")
                    {
                        propValue = DateTime.Now;
                    }

                    queryLine.Add($"{propName} = @{propName}");
                    dynamicParameters.Add($"@{propName}", propValue);
                }

                dynamicParameters.Add("@oldEntityId", entityId);
                var sqlQuery = $"UPDATE {_className} SET {String.Join(", ", queryLine.ToArray())} " +
                                $"WHERE {_className}Id = @oldEntityId";
                rowEffects = mySqlConnection.Execute(sqlQuery, param: dynamicParameters, transaction: transaction);

                transaction.Commit();
            }
            catch (Exception)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw;
            }
            finally
            {
                if (mySqlConnection != null) mySqlConnection.Close();
            }
            return rowEffects;
        }
        #endregion

        #region DeleteOne
        /// <summary>
        /// Xóa theo Id
        /// </summary>
        /// <param name="entityId">Id </param>
        /// <returns>Số bản ghi được xóa</returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        public int Delete(Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var sqlCommand = $"DELETE FROM {_className} WHERE {_className}ID = @{_className}ID";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{_className}ID", entityId);
                var rowEffects = _dbConnection.Execute(sqlCommand, param: parameters);
                return rowEffects;
            }

        }
        #endregion

        #region DeleteMany

        /// <summary>
        /// Xóa nhiều 
        /// </summary>
        /// <param name="entityIds"> mảng chứa các Id</param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(19/8/2021)
        /// ModifiedBy: NTDUNG(19/8/2021)
        public int DeleteMultiple(List<Guid> entityIds)
        {
            MySqlConnection mySqlConnection = null;
            IDbTransaction transaction = null;
            var rowEffects = -1;
            var parameters = new DynamicParameters();
            var paramName = new List<string>();
            
            try
            {
                mySqlConnection = new MySqlConnection(_connectionString);
                mySqlConnection.Open();
                transaction = mySqlConnection.BeginTransaction();

                for (int i = 0; i < entityIds.Count; i++)
                {
                    var id = entityIds[i];
                    // Đặt tên cho param
                    paramName.Add($"@mID{i}");
                    // Đặt giá trị cho param bằng id 
                    parameters.Add($"@mID{i}", id);
                }
                // Join mảng để tạo ra câu truy vấn xoá nhiều
               
                var sqlCommand = $"DELETE FROM {_className} WHERE {_className}ID IN ({String.Join(", ", paramName.ToArray())})";
                rowEffects = mySqlConnection.Execute(sqlCommand, param: parameters, transaction: transaction);

                transaction.Commit();
            }
            catch(Exception)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw;
            }
            finally
            {
                if (mySqlConnection != null) mySqlConnection.Close();
            }
            return rowEffects;
            
        }
        #endregion

        #region CheckDuplicate
        /// <summary>
        /// Kiểm tra trùng lặp
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fieldName"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public bool CheckDuplicate(TEntity entity, string fieldName, string mode)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                var sqlQuery = "";

                parameters.Add("@fieldValue", entity.GetType().GetProperty(fieldName).GetValue(entity, null));
                parameters.Add("@fieldName", fieldName);
                parameters.Add($"@{_className}ID", (entity.GetType().GetProperty($"{_className}ID").GetValue(entity, null)));

                if (mode == "ADD")
                {
                    sqlQuery = $"SELECT * FROM {_className} WHERE {fieldName} = @fieldValue";
                }
                else if (mode == "UPDATE")
                {
                    sqlQuery = $"SELECT * FROM {_className} WHERE {fieldName} = @fieldValue AND {_className}ID != @{_className}ID";
                }

                // Lấy dữ liệu và phản hồi cho client
                var queryField = _dbConnection.Query<TEntity>(sqlQuery, param: parameters, commandType: CommandType.Text);

                return queryField.ToList().Count() >= 1;
            }
        }
        #endregion

        #region GetNewCode
        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(07/10/2021)
        public string GetNewCode()
        {

            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var proceduce = $"Proc_GetNew{_className}Code";
                var newCode = _dbConnection.Query<string>(proceduce, commandType: CommandType.StoredProcedure);
                return newCode.ToList()[0];
            }
        }
        #endregion
        
        #region GetFilterPaging
        /// <summary>
        /// Lọc và phân trang
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/10/2021)
        public Object GetFilterPaging(string filterString, int pageNumber, int pageSize, List<String> totalFields)
        {
            using(_dbConnection = new MySqlConnection(_connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                if (filterString == null)
                {
                    filterString = "";
                }
                dynamicParameters.Add("@filterString", filterString);
                dynamicParameters.Add("@pageStart", (pageNumber - 1) * pageSize);
                dynamicParameters.Add("@pageSize", pageSize);

                var proceduceFilterPaging = $"Proc_Get{_className}FilterPaging";
                var proceduceFilter = $"Proc_Get{_className}Filter";
                var entitiesFilterPaging = _dbConnection.Query<TEntity>(proceduceFilterPaging, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                var entitiesFilter = _dbConnection.Query<TEntity>(proceduceFilter, param: dynamicParameters, commandType: CommandType.StoredProcedure);

                var totalRecord = entitiesFilter.ToList().Count();

                // Tổng số trang bằng phần nguyên của tổng bán ghi chia cho kích thước, nếu số dư là khác 0 thì cộng thêm 1
                var totalPage = (int)(totalRecord / pageSize) + ((totalRecord % pageSize != 0) ? 1 : 0);

                // Tính toán tổng cho các trường cần tính tổng
                dynamic totalDatas = new ExpandoObject();

                foreach(var field in totalFields)
                {
                    var totalInPage = 0;
                    var totalAll = 0;
                    var properties = entitiesFilter.ToList()[0].GetType().GetProperties();
                    var checkField = false;
                    // Kiểm tra có trường này không
                    foreach (var property in properties)
                    {
                        var propName = property.Name;
                        if (propName == field)
                        {
                            checkField = true;
                            break;
                        }
                    }
                    if (checkField)
                    {
                        foreach(var entities in entitiesFilterPaging)
                        {
                            var value = entities.GetType().GetProperty(field).GetValue(entities);
                            if (value != null)
                                totalInPage += (int)value;
                        };
                        foreach (var entities in entitiesFilter)
                        {
                            var value = entities.GetType().GetProperty(field).GetValue(entities);
                            if (value != null)
                                totalAll += (int)value;
                        };
                        var totalData = new
                        {
                            InPage = totalInPage,
                            All = totalAll
                        };
                        AddProperty(totalDatas, field, totalData);
                    } 
                }
                
                // Trả về
                var filterResult = new
                {
                    TotalPage = totalPage,
                    TotalRecord = totalRecord,
                    TotalDatas = totalDatas,
                    Records = entitiesFilterPaging
                };
    
                return filterResult;
            }    
        }
        public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }
        #endregion

        #region UpdateColumns
        /// <summary>
        /// Cập nhật theo các cột
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (14/11/2021) 
        public int UpdateColumns(TEntity entity, Guid entityId, List<string> columns)
        {
            MySqlConnection mySqlConnection = null;
            IDbTransaction transaction = null;
            var rowEffects = -1;

            try
            {
                mySqlConnection = new MySqlConnection(_connectionString);
                mySqlConnection.Open();
                transaction = mySqlConnection.BeginTransaction();

                var queryLine = new List<string>();
                DynamicParameters dynamicParameters = new DynamicParameters();
                var properties = entity.GetType().GetProperties();
                foreach (var property in properties)
                {
                    // Nếu thuộc tính không cần thêm vào thì bỏ qua
                    if (property.IsDefined(typeof(EddieNotMap), false)) continue;

                    var propName = property.Name;
                    // Kiểm tra có thuộc colums gửi lên không
                    var checkColumn = columns.Contains(propName);
                    if (!checkColumn) continue;

                    var propValue = property.GetValue(entity);
                    // Gán Id cũ
                    if (propName.Equals($"{_className}ID") && property.PropertyType == typeof(Guid))
                    {
                        propValue = entityId;
                    }
                    // Bổ sung ngày chỉnh sửa
                    if (propName == "ModifiedDate")
                    {
                        propValue = DateTime.Now;
                    }

                    queryLine.Add($"{propName} = @{propName}");
                    dynamicParameters.Add($"@{propName}", propValue);
                }

                dynamicParameters.Add("@oldEntityId", entityId);
                var sqlQuery = $"UPDATE {_className} SET {String.Join(", ", queryLine.ToArray())} " +
                                $"WHERE {_className}Id = @oldEntityId";
                rowEffects = mySqlConnection.Execute(sqlQuery, param: dynamicParameters, transaction: transaction);

                transaction.Commit();
            }
            catch (Exception)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw;
            }
            finally
            {
                if (mySqlConnection != null) mySqlConnection.Close();
            }
            return rowEffects;
        } 
        #endregion 
        #endregion
    }
}
