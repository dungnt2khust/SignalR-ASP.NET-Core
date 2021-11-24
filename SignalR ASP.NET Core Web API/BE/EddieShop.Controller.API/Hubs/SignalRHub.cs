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
        IBaseRepository<User> _userRepository;
        IBaseService<Admin> _adminService;
        #endregion

        #region Contructor
        public SignalRHub(IBaseService<User> userService, IBaseService<Admin> adminService, IBaseRepository<User> userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
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
        
        #region SendMessageToSpecialUser
        /// <summary>
        /// Gửi tin nhắn đến user 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="message"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public async Task SendMessageToSpecialUser(User userSent, string userName, string message)
        {
            // Lấy connectionid của username truyền lên
            var userQuery = new User();
            userQuery.Name = userName;
            IEnumerable<User> users = _userRepository.GetByValueColumns(userQuery);
            if (users != null)
            {
                IReadOnlyList<string> userConnectionIDs = users.Select(user => user.ConnectionID).ToList().AsReadOnly();
                await Clients.Clients(userConnectionIDs).SendAsync("ReceiveMessage", userSent, message);
            }
            else 
                await Clients.Client(userSent.ConnectionID).SendAsync("Result", message);
        }
        #endregion

        #region SendMessageToUsers
        /// <summary>
        /// Gửi tin nhắn đến người dùng
        /// </summary>
        /// <param name="userSent"></param>
        /// <param name="usersReceive"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (24/11/2021)
        public async Task SendMessageToUsers(User userSent, List<Guid> userReceiveIDs, string message)
        {
            IReadOnlyList<string> connectionIDs;
            List<User> userReceives = _userRepository.GetByIds(userReceiveIDs);
            connectionIDs = userReceives.Select(user => user.ConnectionID).ToList().AsReadOnly();
            await Clients.Clients(connectionIDs).SendAsync("ReceiveMessage", userSent, message);
        }
        #endregion

        #region SendNotifyToUsers
        /// <summary>
        /// Gửi tin nhắn đến người dùng
        /// </summary>
        /// <param name="userSent"></param>
        /// <param name="usersReceive"></param>
        /// <param name="notify"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (24/11/2021)
        public async Task SendNotifyToUsers(User userSent, List<Guid> userReceiveIDs, object notify)
        {
            IReadOnlyList<string> connectionIDs;
            List<User> userReceives = _userRepository.GetByIds(userReceiveIDs);
            connectionIDs = userReceives.Select(user => user.ConnectionID).ToList().AsReadOnly();
            await Clients.Clients(connectionIDs).SendAsync("ReceiveNotify", userSent, notify);
        }
        #endregion

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