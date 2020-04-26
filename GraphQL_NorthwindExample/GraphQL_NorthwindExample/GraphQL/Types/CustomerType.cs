using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL_NorthwindExample.Api.Data.Entities;
using GraphQL_NorthwindExample.Api.Repositories;

namespace GraphQL_NorthwindExample.Api.GraphQL.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType(OrderRepository orderRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.FirstName);
            Field(t => t.LastName);
            Field(t => t.City);
            Field(t => t.Country);
            Field(t => t.Phone).Description("personal telephone number of the customer");

            Field<ListGraphType<OrderType>>(
               "orders",
               resolve: context =>
               {
                   var loader =
                       dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Order>(
                           "GetOrdersByCustomerId", orderRepository.GetForCustomers);
                   return loader.LoadAsync(context.Source.Id);
               });
        }

    }
}

