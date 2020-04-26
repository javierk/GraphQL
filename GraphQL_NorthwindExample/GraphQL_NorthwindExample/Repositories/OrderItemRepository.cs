using GraphQL_NorthwindExample.Api.Data;
using GraphQL_NorthwindExample.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_NorthwindExample.Api.Repositories
{
    public class OrderItemRepository
    {
        private readonly NorthwindDbContext _dbContext;

        public OrderItemRepository(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<OrderItem>> GetAll()
        {
            return _dbContext.OrderItem.ToListAsync();
        }

        public Task<OrderItem> GetOne(int id)
        {
            return _dbContext.OrderItem.SingleAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<OrderItem>> GetForProduct(int productId)
        {
            return await _dbContext.OrderItem.Where(oi => oi.ProductId == productId).ToListAsync();
        }

        public async Task<ILookup<int, OrderItem>> GetForProducts(IEnumerable<int> productIds)
        {
            var orderItems = await _dbContext.OrderItem.Where(oi => productIds.Contains(oi.ProductId)).ToListAsync();
            return orderItems.ToLookup(o => o.ProductId);
        }

        public async Task<IEnumerable<OrderItem>> GetForOrder(int orderId)
        {
            return await _dbContext.OrderItem.Where(oi => oi.OrderId == orderId).ToListAsync();
        }

        public async Task<ILookup<int, OrderItem>> GetForOrders(IEnumerable<int> orderIds)
        {
            var orderItems = await _dbContext.OrderItem.Where(oi => orderIds.Contains(oi.OrderId)).ToListAsync();
            return orderItems.ToLookup(o => o.OrderId);
        }
    }
}
