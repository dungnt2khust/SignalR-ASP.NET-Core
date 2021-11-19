using EddieShop.Core.Entities;
using EddieShop.Core.Entities.Common;
using EddieShop.Core.Interfaces.Base;
using EddieShop.Core.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EddieShop.Core.Enums.EddieShopEnum;

namespace EddieShop.Controller.API.Hubs
{
    public class SignalRHub : Hub
    {
        #region Declare
        IBaseService<User> _userService;
        IBaseService<Admin> _adminService;
        #endregion

        #region Contructor
        public SignalRHub(IBaseService<User> userService, IBaseService<Admin> adminService)
        {
            _userService = userService;
            _adminService = adminService;
        }
        #endregion

        #region Method
        #region OnConnectedAsync
        /// <summary>
        /// Client kết nối với server
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
        #endregion

        #region UpdateConnectionID
        /// <summary>
        /// Cập nhật connectionID mới cho tài khoản
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (15/11/2021)
        /// ModifiedBy: NTDUNG (19/11/2021)
        public ServiceResult UpdateConnectionID(AccountData accountData)
        {
            List<string> columns = new List<string>();
            var serviceResult = new ServiceResult();

            columns.Add("ConnectionID");

            var _accountId = accountData.AccountId;

            switch(accountData.AccountType)
            {
                case (int)AccountType.USER:
                    var newDataUser = new User();
                    newDataUser.ConnectionID = Context.ConnectionId;
                    serviceResult = _userService.UpdateColumns(newDataUser, _accountId, columns);
                    break;
                case (int)AccountType.ADMIN:
                    var newDataAdmin = new Admin();
                    newDataAdmin.ConnectionID = Context.ConnectionId;
                    serviceResult = _adminService.UpdateColumns(newDataAdmin, _accountId, columns);
                    break;
            }

            serviceResult.Data = new
            {
                ConnectionID = Context.ConnectionId
            };
            return serviceResult;
        }
        #endregion


        public async Task SendMessage(string user, string message, int userID)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, userID, Context.ConnectionId);
        }
        public async Task SendMessageToSpecialUser(string connectionID, string message)
        {
            await Clients.Client(connectionID).SendAsync("ReceiveMessageAdmin", connectionID, message);
        }

        /// <summary>
        /// Lấy connectionID
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (14/11/2021)
        public string GetConnectionID()
        {
            return Context.ConnectionId;
        }

        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    _connections.Remove(Context.User.Identity.Name, Context.ConnectionId);

        //    return base.OnDisconnected(stopCalled);
        //}

        //public override Task OnReconnected()
        //{
        //    if (!_connections.GetConnections(Context.User.Identity.Name).Contains(Context.ConnectionId))
        //    {
        //        _connections.Add(Context.User.Identity.Name, Context.ConnectionId);
        //    }

        //    return base.OnReconnected();
        //}
        #endregion
    }
}