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
        /// <param name="type"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (15/11/2021)
        public Object checkValidAccount(Account account, string type)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@Name", account.Name);
                dynamicParameters.Add($"@PassWord", account.PassWord);

                var tableName = "";
                switch(type)
                {
                    case "Admin":
                        tableName = "Admin";
                        break;
                    case "User":
                        tableName = "User";
                        break;
                }
                var sqlCommand = $"SELECT * FROM {tableName} WHERE Name = @Name AND PassWord = @PassWord";
                var entity = _dbConnection.QueryFirstOrDefault<Account>(sqlCommand, param: dynamicParameters);

                if (entity == null)
                {
                    return new {
                        ValidAccount = false,
                        Msg = ResourceVN.Account_Invalid,
                    };  
                } else
                {
                    return new
                    {
                        ValidAccount = true,
                        Msg = ResourceVN.Account_Valid,
                        SessionID = entity.SessionID
                    };
                }
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
                    AccountType = AccountType.ADMIN,
                    Data = new { }
                };
            }
        }
        #endregion
        #endregion
    }
}
