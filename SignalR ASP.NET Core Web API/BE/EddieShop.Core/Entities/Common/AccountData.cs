using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Entities.Common
{
    public class AccountData
    {
        /// <summary>
        /// Loại tài khoản
        /// </summary>
        public int AccountType { get; set; }

        /// <summary>
        /// Thông tin tài khoản
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Id tài khoản
        /// </summary>
        public Guid AccountId { get; set; }
    }
}
