using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Attributes
{
    public class EddieShopAttributes
    {
        /// <summary>
        /// Attribute: Trường bắt buộc nhập
        /// </summary>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
        public class EddieRequired : Attribute
        {
        }

        /// <summary>
        /// Attribute: hiển thị tên trường
        /// </summary>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
        public class EddieDisplayName : Attribute
        {
            public EddieDisplayName(string name)
            {
                FieldName = name;
            }
            public string FieldName { get; set; }
        }

        /// <summary>
        /// Attribute: những Property của đối tượng không map với cơ sở dữ liệu
        /// </summary>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
        public class EddieNotMap : Attribute
        {

        }

        /// <summary>
        /// Attribute: Những trường không được phép trùng
        /// </summary>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
        public class EddieUnique : Attribute
        {

        }

        /// <summary>
        /// Attribute: Những trường xuất ra file excel
        /// </summary>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
        public class EddieExport : Attribute
        {
            public EddieExport(string name)
            {
                FieldName = name;
            }
            public string FieldName { get; set; }
        }
    }
}
