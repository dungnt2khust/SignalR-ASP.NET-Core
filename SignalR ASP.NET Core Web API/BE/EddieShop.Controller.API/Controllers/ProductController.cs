using EddieShop.Core.Entities;
using EddieShop.Core.Interfaces.Base;
using EddieShop.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EddieShop.Controller.API.Controllers
{
    public class ProductController : BaseController<Product>
    {
        #region Declare
        IProductService _productService;
        #endregion
        public ProductController(IBaseService<Product> baseService, IProductService productService) : base(baseService)
        {
            _productService = productService;
        }
    }
}
