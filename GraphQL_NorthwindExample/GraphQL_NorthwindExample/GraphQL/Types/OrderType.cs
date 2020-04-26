using GraphQL_NorthwindExample.Api.Data.Entities;
using GraphQL.Types;
using GraphQL_NorthwindExample.Api.Repositories;
using GraphQL.DataLoader;

namespace GraphQL_NorthwindExample.Api.GraphQL.Types
{
    public class OrderType: ObjectGraphType<Order>
    {
        public OrderType(OrderItemRepository orderItemRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.OrderDate);
            Field(t => t.OrderNumber);
            Field(t => t.TotalAmount);

            Field<ListGraphType<OrderItemType>>(
              "orderItems",
              resolve: context =>
              {
                  var loader =
                      dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, OrderItem>(
                          "GetOrderItemsByOrderId", orderItemRepository.GetForOrders);
                  return loader.LoadAsync(context.Source.Id);
              });
        }
    }
}
