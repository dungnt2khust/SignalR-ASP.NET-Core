using Dapper;
using EddieShop.Core.Entities;
using EddieShop.Core.Interfaces.Repository;
using EddieShop.Core.Resources;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static EddieShop.Core.Enums.EddieShopEnum;

namespace EddieShop.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        #region DECLARE
        protected IConfiguration _configuration;
        protected IDbConnection _dbConnection;
        protected string _connectionString = string.Empty;
        private string _className;

        #endregion

        #region CONSTRUCTOR
        public AccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("EddieShopConnection");
            _className = "Account";
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
        public Object checkValidAccount(Account account)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@Name", account.Name);
                dynamicParameters.Add($"@PassWord", account.PassWord);

                var sqlCommandAdmin = $"SELECT * FROM Admin WHERE Name = @Name AND PassWord = @PassWord";
                var entityAdmin = _dbConnection.QueryFirstOrDefault<Admin>(sqlCommandAdmin, param: dynamicParameters);

                var sqlCommandUser = $"SELECT * FROM User WHERE Name = @Name AND PassWord = @PassWord";
                var entityUser = _dbConnection.QueryFirstOrDefault<User>(sqlCommandUser, param: dynamicParameters);

                if (entityUser != null)
                {
                    return new
                    {
                        AccountType = AccountType.USER,
                        Data = entityUser,
                        AccountId = entityUser.UserID
                    };
                }
                if (entityAdmin != null)
                {
                    return new
                    {
                        AccountType = AccountType.ADMIN,
                        Data = entityAdmin,
                        AccountId = entityAdmin.AdminID
                    };
                }
                return new
                {
                    AccountType = AccountType.GUEST,
                    Data = new { }
                };
            }
        }
        #endregion

        #region CheckSession
        /// <summary>
        /// Kiểm tra session hợp lệ không
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (15/11/2021)
        public Object checkSession(Guid? sessionID)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@SessionID", sessionID);
 
                var sqlCommandAdmin = $"SELECT * FROM Admin WHERE SessionID = @SessionID";
                var sqlCommandUser = $"SELECT * FROM User WHERE SessionID = @SessionID";
                var entityAdmin = _dbConnection.QueryFirstOrDefault<Admin>(sqlCommandAdmin, param: dynamicParameters);
                var entityUser = _dbConnection.QueryFirstOrDefault<User>(sqlCommandUser, param: dynamicParameters);

                if (entityUser != null)
                {
                    return new
                    {
                        AccountType = AccountType.USER,
                        Data = entityUser,
                        AccountId = entityUser.UserID
                    };
                }
                if (entityAdmin != null)
                {
                    return new
                    {
                        AccountType = AccountType.ADMIN,
                        Data = entityAdmin,
                        AccountId = entityAdmin.AdminID
                    }; 
                }
                return new
                {
                    AccountType = AccountType.GUEST,
                    Data = new { }
                };
            }
        }
        #endregion
        #endregion
    }
}
