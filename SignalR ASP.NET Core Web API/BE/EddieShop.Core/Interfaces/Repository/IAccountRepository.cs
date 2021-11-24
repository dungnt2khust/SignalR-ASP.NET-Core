using EddieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Interfaces.Repository
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Kiểm tra tài khoản hợp lệ
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (15/11/2021)
        /// ModifiedBy: NTDUNG (22/11/2021)
        Object checkValidAccount(Account account);

        /// <summary>
        /// Kiểm tra sessionID có hợp lệ không
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (15/11/2021)
        Object checkSession(Guid? sessionID);
    }
}
