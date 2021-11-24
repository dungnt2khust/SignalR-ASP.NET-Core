using EddieShop.Core.Entities;
using EddieShop.Core.Interfaces.Repository;
using EddieShop.Core.Interfaces.Services;
using EddieShop.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Services
{
    public class AccountService : IAccountService
    {
        #region DECLARE
        protected IAccountRepository _accountRepository;
        #endregion

        #region Constructor
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        #endregion

        #region Methods
        #region CheckValidAccount
        /// <summary>
        /// Kiểm tra tài khoản hợp lệ
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (15/11/2021)
        /// ModifiedBy: NTDUNG (22/11/2021)
        public ServiceResult checkValidAccount(Account account)
        {
            try
            {
                var serviceResult = new ServiceResult();
                serviceResult.Data = _accountRepository.checkValidAccount(account);
                return serviceResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region CheckSession
        /// <summary>
        /// Kiểm tra session hợp lệ
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (15/11/2021)
        public ServiceResult checkSession(Guid? sessionID)
        {
            try
            {
                var serviceResult = new ServiceResult();
                serviceResult.Data = _accountRepository.checkSession(sessionID);
                return serviceResult;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #endregion
    }
}
