using GraphQL_NorthwindExample.Api.Data;
using GraphQL_NorthwindExample.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GraphQL_NorthwindExample.Api.Repositories
{
    public class SupplierRepository
    {
        private readonly NorthwindDbContext _dbContext;

        public SupplierRepository(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Supplier>> GetAll()
        {
            return  _dbContext.Supplier.ToListAsync();
        }

        public Task<Supplier> GetOne(int id)
        {
            return _dbContext.Supplier.SingleAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Supplier>> GetForCountry(string country)
        {
            return await _dbContext.Supplier.Where(s => s.Country == country).ToListAsync();
        }
    }
}
