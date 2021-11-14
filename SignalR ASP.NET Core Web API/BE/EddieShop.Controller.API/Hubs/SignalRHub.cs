using EddieShop.Core.Entities;
using EddieShop.Core.Interfaces.Base;
using EddieShop.Core.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EddieShop.Controller.API.Hubs
{
    public class SignalRHub : Hub
    {
        #region Declare
        IBaseService<User> _userService;
        #endregion

        #region Contructor
        public SignalRHub(IBaseService<User> userService)
        {
            _userService = userService;         
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
        /// Cập nhật connectionID mới
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (14/11/2021)
        public ServiceResult UpdateConnectionID(User user)
        {
            List<string> columns = new List<string>();
            columns.Add("ConnectionID");
            user.ConnectionID = Context.ConnectionId;

            var serviceResult = _userService.UpdateColumns(user, user.UserID, columns);
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
