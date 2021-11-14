using EddieShop.Core.Entities;
using EddieShop.Core.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EddieShop.Controller.API.Controllers
{
    public class UserController : BaseController<User>
    {
        public UserController(IBaseService<User> baseService) : base(baseService)
        {
        }

    }
}
