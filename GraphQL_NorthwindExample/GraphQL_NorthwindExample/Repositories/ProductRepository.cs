using GraphQL_NorthwindExample.Api.Data;
using GraphQL_NorthwindExample.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_NorthwindExample.Api.Repositories
{
    public class ProductRepository
    {
        private readonly NorthwindDbContext _dbContext;
        public ProductRepository(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Product>> GetAll()
        {
            return _dbContext.Product.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetForSupplier(int supplierId)
        {
            return await _dbContext.Product.Where(p => p.SupplierId == supplierId).ToListAsync();
        }

        public async Task<ILookup<int, Product>> GetForSuppliers(IEnumerable<int> supplierIds)
        {
            var products = await _dbContext.Product.Where(p => supplierIds.Contains(p.SupplierId)).ToListAsync();
            return products.ToLookup(o => o.SupplierId);
        }
        public async Task<Product> AddProduct(Product product)
        {
            _dbContext.Product.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
    }
}
