using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Entities
{
    public class Admin : Account
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid? AdminID { get; set; }
    }
}
