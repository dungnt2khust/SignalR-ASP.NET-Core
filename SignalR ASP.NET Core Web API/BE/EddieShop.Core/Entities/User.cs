using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Entities
{
    public class User : Account
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid? UserID { get; set; }
    }
}
