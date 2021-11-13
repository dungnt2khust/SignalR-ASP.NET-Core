﻿using EddieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Interfaces.Base
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>  
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        ServiceResult GetAllEntities();

        /// <summary>
        /// Lấy thông tin theo Id
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        ServiceResult GetEntityById(Guid entityId);

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thông tin được thêm</param>
        /// <returns>số bản ghi được thêm</returns>
        //// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        ServiceResult Insert(TEntity entity);

        /// <summary>
        /// Sửa thông tin
        /// </summary>
        /// <param name="entity">Thông tin cần sửa</param>
        /// <param name="entityId">Id </param>
        /// <returns>số bản ghi được sửa</returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        ServiceResult Update(TEntity entity, Guid entityId);

        /// <summary>
        /// Xóa theo Id
        /// </summary>
        /// <param name="entityId">Id </param>
        /// <returns>Số bản ghi được xóa</returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        ServiceResult Delete(Guid entityId);

        /// <summary>
        /// Xóa nhiều
        /// </summary>
        /// <param name="entityIds"> mảng chứa các Id</param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        ServiceResult DeleteMultiple(List<Guid> entityIds);

        /// <summary>
        /// Validate data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(04/10/2021)
        ServiceResult ValidateData(TEntity entity, string mode);


        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(07/10/2021)
        ServiceResult GetNewCode();

        /// <summary>
        /// Lọc và phân trang
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalFields"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/10/2021)
        ServiceResult GetFilterPaging(string filterString, int pageNumber, int pageSize, List<String> totalFields);

        /// <summary>
        /// Thêm mới Master Detail
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(28/10/2021)
        //ServiceResult InsertMasterDetail(Object data);
    }
}
