using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Entities
{
    public class UpdateColumns<TEntity>
    {
        /// <summary>
        /// Thông tin cập nhật mới
        /// </summary>
        public TEntity Entity { get; set; }

        /// <summary>
        /// Các cột cần cập nhật
        /// </summary>
        public List<string> Columns { get; set; }
    }
}
