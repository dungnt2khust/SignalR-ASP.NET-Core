using System;
using System.Collections.Generic;

namespace EddieShop.Core.Interfaces.Base
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>  
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        IEnumerable<TEntity> GetAllEntities();

        /// <summary>
        /// Lấy thông tin theo Id
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        TEntity GetEntityById(Guid entityId);



        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thông tin được thêm</param>
        /// <returns>số bản ghi được thêm</returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        int Insert(TEntity entity);

        /// <summary>
        /// Sửa thông tin
        /// </summary>
        /// <param name="entity">Thông tin cần sửa</param>
        /// <param name="entityId">Id </param>
        /// <returns>số bản ghi được sửa</returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        int Update(TEntity entity, Guid entityId);

        /// <summary>
        /// Xóa theo Id
        /// </summary>
        /// <param name="entityId">Id </param>
        /// <returns>Số bản ghi được xóa</returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        int Delete(Guid entityId);

        /// <summary>
        /// Lấy thông tin theo property
        /// </summary>
        /// <param name="columnsGet">Tên property</param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        TEntity GetEntityByProperties(object columnsGet);

        /// <summary>
        /// Lấy thông tin theo property
        /// </summary>
        /// <param name="columnsGet">Tên property</param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        List<TEntity> GetByValueColumns(TEntity columnsGet);

        /// <summary>
        /// Lấy theo các id 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (24/11/2021)
        List<TEntity> GetByIds(List<Guid> ids);

        /// <summary>
        /// Xóa nhiều 
        /// </summary>
        /// <param name="entityIds"> mảng chứa các Id</param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        int DeleteMultiple(List<Guid> entityIds);

        /// <summary>
        /// Kiểm tra trùng lặp
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fieldName"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(04/10/2021)
        Boolean CheckDuplicate(TEntity entity, string fieldName, string mode);

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(07/10/2021)
        string GetNewCode();

        /// <summary>
        /// Lọc và phân trang 
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalFields"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/10/2021)
        Object GetFilterPaging(string filterString, int pageNumber, int pageSize, List<String> totalFields);

        /// <summary>
        /// Cập nhật theo tên cột
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (14/11/2021)
        int UpdateColumns(TEntity entity, Guid entityId, List<string> columns);
    }
}
