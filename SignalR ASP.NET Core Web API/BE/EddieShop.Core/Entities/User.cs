using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Entities
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// PassWord
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// Mã người dùng
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// Tên hiển thị
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Loại khách hàng
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// SessionID
        /// </summary>
        public Guid? SessionID { get; set; }

        /// <summary>
        /// ConnectionID
        /// </summary>
        public string ConnectionID { get; set; }
    }
}
