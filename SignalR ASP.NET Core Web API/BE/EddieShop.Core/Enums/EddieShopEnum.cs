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
    }
}
