using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Entities
{
    public class ServiceResult
    {
        /// <summary>
        /// Hợp lệ hay không
        /// </summary>
        public bool Success { get; set; } = true;
    
        /// <summary>
        /// Dữ liệu trả về 
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Thông điệp đi kèm
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// Thông điệp cho Developer
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Mã code 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Thông tin liên quan
        /// </summary>
        public string MoreInfo { get; set; }

        /// <summary>
        /// Id tìn kiếm
        /// </summary>
        public string TraceId { get; set; }
    }
}
