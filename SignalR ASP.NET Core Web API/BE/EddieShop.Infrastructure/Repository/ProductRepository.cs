using EddieShop.Core.Entities;
using EddieShop.Core.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Infrastructure.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        #region Constructor
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion
        
    }
}
