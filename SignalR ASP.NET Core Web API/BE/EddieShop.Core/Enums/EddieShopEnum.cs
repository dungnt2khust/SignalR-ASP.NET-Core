using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Enums
{
    public class EddieShopEnum
    {
        /// <summary>
        /// Trạng thái của detail 
        /// </summary>
        public enum DetailEntityState
        {
            // Thêm
            ADD = 0,
            // Cập nhật
            UPDATE = 1,
            // Xoá
            DELETE = 2
        }

        /// <summary>
        /// Loại tài khoản
        /// </summary>
        public enum AccountType
        {
            // Khách
            GUEST = 0,
            // Người dùng
            USER = 1,
            // Quản trị viên
            ADMIN = 2
        }
    }
}
