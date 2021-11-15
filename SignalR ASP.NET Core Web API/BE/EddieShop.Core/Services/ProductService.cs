using EddieShop.Core.Entities;
using EddieShop.Core.Interfaces.Base;
using EddieShop.Core.Interfaces.Repository;
using EddieShop.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        #region Declare
        IProductRepository _productRepository;
        #endregion
        
        #region Contructor
        public ProductService(IBaseRepository<Product> baseRepository, IProductRepository productRepository) : base(baseRepository)
        {
            _productRepository = productRepository;
        }
        #endregion
        
    }
}
