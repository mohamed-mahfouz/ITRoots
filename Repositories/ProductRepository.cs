using ITRoots.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITRoots.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository()
        {
            this._dbContext = new ApplicationDbContext();
        }

        public IEnumerable<Product> GetProducts()
        {
           return _dbContext.Products.ToList();
        }
    }
}