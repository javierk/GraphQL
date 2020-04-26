using GraphQL_NorthwindExample.Api.Data;
using GraphQL_NorthwindExample.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL_NorthwindExample.Api.Repositories
{
    public class CustomerRepository
    {
        private readonly NorthwindDbContext _dbContext;

        public CustomerRepository(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Customer>> GetAll()
        {
            return _dbContext.Customer.ToListAsync();
        }

        public Task<Customer> GetOne(int id)
        {
            return _dbContext.Customer.SingleAsync(p => p.Id == id);
        }
    }
}
