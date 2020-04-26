using GraphQL_NorthwindExample.Api.Data;
using GraphQL_NorthwindExample.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_NorthwindExample.Api.Repositories
{
    public class OrderRepository
    {
        private readonly NorthwindDbContext _dbContext;
        public OrderRepository(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Order>> GetAll()
        {
            return _dbContext.Order.ToListAsync();
        }

        public Task<Order> GetOne(int id)
        {
            return _dbContext.Order.SingleAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Order>> GetForCustomer(int customerId)
        {
            return await _dbContext.Order.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<ILookup<int, Order>> GetForCustomers(IEnumerable<int> customerIds)
        {
            var orders = await _dbContext.Order.Where(o => customerIds.Contains(o.CustomerId)).ToListAsync();
            return orders.ToLookup(o => o.CustomerId);
        }
    }
}
