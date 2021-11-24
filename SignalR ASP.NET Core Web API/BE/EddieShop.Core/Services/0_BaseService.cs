using EddieShop.Core.Entities;
using EddieShop.Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static EddieShop.Core.Attributes.EddieShopAttributes;

namespace EddieShop.Core.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        #region DECLARE
        protected IBaseRepository<TEntity> _baseRepository;
        string _className;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _className = typeof(TEntity).Name;
        }

        #endregion

        #region Method

        #region GetAll
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>  
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        public ServiceResult GetAllEntities()
        {
            try
            {
                var serviceResult = new ServiceResult();
                serviceResult.Data = _baseRepository.GetAllEntities();
                return serviceResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region GetByID
        /// <summary>
        /// Lấy thông tin theo Id
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        public virtual ServiceResult GetEntityById(Guid entityId)
        {
            try
            {
                var serviceResult = new ServiceResult();
                serviceResult.Data = _baseRepository.GetEntityById(entityId);
                return serviceResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region GetByProperties
        /// <summary>
        /// Lấy dữ liệu theo thuộc tính
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (23/11/2021)
        public ServiceResult GetEntityByProperties(object columnsGet)
        {
            try
            {
                var serviceResult = new ServiceResult();
                serviceResult.Data = _baseRepository.GetEntityByProperties(columnsGet);
                return serviceResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region GetByValueColumns
        /// <summary>
        /// Lấy dữ liệu theo thuộc tính
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (23/11/2021)
        public ServiceResult GetByValueColumns(TEntity columnsGet)
        {
            try
            {
                var serviceResult = new ServiceResult();
                serviceResult.Data = _baseRepository.GetByValueColumns(columnsGet);
                return serviceResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region GetByIds
        /// <summary>
        /// Lấy theo các ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (24/11/2021)
        public ServiceResult GetByIds(List<Guid> ids)
        {
            try
            {
                var serviceResult = new ServiceResult();
                serviceResult.Data = _baseRepository.GetByIds(ids);
                return serviceResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        
        #region Insert
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thông tin được thêm</param>
        /// <returns>số bản ghi được thêm</returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        public ServiceResult Insert(TEntity entity)
        {
            try
            {
                //Validate dữ liệu
                //Validate chung
                List<string> emptyArr = new List<string>();
                var serviceResult = ValidateData(entity, "ADD", emptyArr);
                if (!serviceResult.Success)
                {
                    return serviceResult;
                }
                //Thêm dữ liệu
                var rowEffects = _baseRepository.Insert(entity);
                if (rowEffects > 0)
                {
                    serviceResult.Msg = Resources.ResourceVN.Success_Insert;
                } else
                {
                    serviceResult.Msg = Resources.ResourceVN.Fail_Insert;
                }
                serviceResult.Data = new
                {
                    rowEffects = rowEffects,
                };
                return serviceResult;
            }
            catch (Exception)
            {

                throw;
            }

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
        public ServiceResult Update(TEntity entity, Guid entityId)
        {
            try
            {
                //Validate dữ liệu
                //Validate chung
                List<string> emptyArr = new List<string>();
                var serviceResult = ValidateData(entity, "UPDATE", emptyArr);
                if (!serviceResult.Success)
                {
                    return serviceResult;
                }
                //Thêm dữ liệu
                var rowEffects = _baseRepository.Update(entity, entityId);
                serviceResult.Data = new
                {
                    rowEffects = rowEffects,
                };
                if (rowEffects > 0)
                    serviceResult.Msg = Resources.ResourceVN.Success_Update;
                else
                    serviceResult.Msg = Resources.ResourceVN.Fail_Update;

                return serviceResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region ValidateData
        /// <summary>
        /// Validate data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="mode"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(07/10/2021)
        /// ModifiedBy: NTDUNG (14/11/2021)
        public ServiceResult ValidateData(TEntity entity, string mode, List<string> columns)
        {
            var serviceResult = new ServiceResult();
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propName = property.Name;

                // Trong trường hợp cập nhật một số cột thì chỉ cần validate những cột đó
                if (mode == "UPDATE")
                {
                    var checkColumn = columns.Contains(propName);
                    if (!checkColumn) continue;
                }

                var propValue = property.GetValue(entity);
                var propEddieDislayName = property.GetCustomAttributes(typeof(EddieDisplayName), true);

                // Trường bắt buộc
                if (property.IsDefined(typeof(EddieRequired), false))
                {
                    var fieldName = propEddieDislayName.Length > 0 ? (propEddieDislayName[0] as EddieDisplayName).FieldName : property.Name;
                    if (propValue == null || propValue.ToString() == "")
                    {
                        serviceResult.Success = false;
                        serviceResult.Msg = string.Format(Resources.ResourceVN.Exception_Required, fieldName);
                        return serviceResult;
                    }
                };
                // Kiểm tra trùng lặp
                if (property.IsDefined(typeof(EddieUnique), false))
                {
                    var fieldName = propEddieDislayName.Length > 0 ? (propEddieDislayName[0] as EddieDisplayName).FieldName : property.Name;

                    var duplicate = _baseRepository.CheckDuplicate(entity, propName, mode);
                    if (duplicate)
                    {
                        serviceResult.Success = false;
                        serviceResult.Msg = string.Format(Resources.ResourceVN.Exception_Duplication, fieldName);
                        return serviceResult;
                    }
                };
            }
            serviceResult.Success = true;
            return serviceResult;
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
        public ServiceResult Delete(Guid entityId)
        {
            try
            {
                var serviceResult = new ServiceResult();
                var rowEffects = _baseRepository.Delete(entityId);
                serviceResult.Data = new
                {
                    rowEffects = rowEffects,
                };
                if (rowEffects > 0)
                    serviceResult.Msg = Resources.ResourceVN.Success_Delete;
                else 
                    serviceResult.Msg = Resources.ResourceVN.Fail_Delete;

                return serviceResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region DeleteMany
        /// <summary>
        /// Xóa nhiều
        /// </summary>
        /// <param name="entityIds"> mảng chứa các Id</param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        public ServiceResult DeleteMultiple(List<Guid> entityIds)
        {
            try
            {
                var serviceResult = new ServiceResult();
                var rowEffects = _baseRepository.DeleteMultiple(entityIds);
                serviceResult.Data = new
                {
                    rowEffects = rowEffects,
                };
                if (rowEffects > 0)
                    serviceResult.Msg = Resources.ResourceVN.Success_Delete;
                else
                    serviceResult.Msg = Resources.ResourceVN.Fail_Delete;
                return serviceResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region GetNewCode
        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(07/10/2021)
        public ServiceResult GetNewCode()
        {
            try
            {
                var serviceResult = new ServiceResult();
                serviceResult.Data = _baseRepository.GetNewCode();
                return serviceResult;
            }
            catch (Exception)
            {
                throw;
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
        /// <param name="totalFields"
        /// <returns></returns>
        /// CreatedBy: NTDUNG(28/10/2021)
        public ServiceResult GetFilterPaging(string filterString, int pageNumber, int pageSize, List<String> totalFields)
        {
            try
            {
                var serviceResult = new ServiceResult();
                serviceResult.Data = _baseRepository.GetFilterPaging(filterString, pageNumber, pageSize, totalFields);
                return serviceResult;
            }
            catch (Exception)
            {
                throw;
            }
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
        public ServiceResult UpdateColumns(TEntity entity, Guid entityId, List<String> columns)
        {
            try
            {
                //Validate dữ liệu
                //Validate chung
                var serviceResult = ValidateData(entity, "UPDATE", columns);
                if (!serviceResult.Success)
                {
                    return serviceResult;
                }
                //Thêm dữ liệu
                var rowEffects = _baseRepository.UpdateColumns(entity, entityId, columns);
                serviceResult.Data = new
                {
                    rowEffects = rowEffects,
                };
                if (rowEffects > 0)
                    serviceResult.Msg = Resources.ResourceVN.Success_Update;
                else
                    serviceResult.Msg = Resources.ResourceVN.Fail_Update;

                return serviceResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #endregion
    }
}
