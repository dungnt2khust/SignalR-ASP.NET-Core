using EddieShop.Core.Entities;
using EddieShop.Core.Interfaces.Services;
using EddieShop.Core.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EddieShop.Controller.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Declare
        IAccountService _accountService;
        #endregion

        #region Constructor
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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
        [HttpPost("check-valid-account")]
        public IActionResult checkValidAccount([FromBody]Account account)
        {
            try
            {
                var serviceResult = _accountService.checkValidAccount(account);
                //4.Trả về kết quả cho client
                if (serviceResult.Success == true)
                {
                    return StatusCode(200, serviceResult);
                }
                else
                {
                    return BadRequest(serviceResult);
                }
            }
            catch (Exception ex)
            {
                var errorObj = new ServiceResult();

                errorObj.Success = false;
                errorObj.Msg = ResourceVN.Exception_ErrorMsg;
                errorObj.DevMsg = ex.Message;
                errorObj.Code = "Eddie-001";
                errorObj.MoreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001";
                errorObj.TraceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb";

                return StatusCode(500, errorObj);
            }
        }
        #endregion

        #region CheckSession
        /// <summary>
        /// Kiểm tra session hợp lệ
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (15/11/2021)
        [HttpPost("check-session")]
        public IActionResult checkSession(Guid? sessionID)
        {
            try
            {
                var serviceResult = _accountService.checkSession(sessionID);
                //4.Trả về kết quả cho client
                if (serviceResult.Success == true)
                {
                    return StatusCode(200, serviceResult);
                }
                else
                {
                    return BadRequest(serviceResult);
                }
            }
            catch (Exception ex)
            {
                var errorObj = new ServiceResult();

                errorObj.Success = false;
                errorObj.Msg = ResourceVN.Exception_ErrorMsg;
                errorObj.DevMsg = ex.Message;
                errorObj.Code = "Eddie-001";
                errorObj.MoreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001";
                errorObj.TraceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb";

                return StatusCode(500, errorObj);
            }
        }
        #endregion
        #endregion
    }
}
