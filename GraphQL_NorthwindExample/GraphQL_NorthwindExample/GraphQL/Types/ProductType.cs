using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL_NorthwindExample.Api.Data.Entities;
using GraphQL_NorthwindExample.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_NorthwindExample.Api.GraphQL.Types
{
    public class ProductType: ObjectGraphType<Product>
    {
        public ProductType(OrderItemRepository orderItemRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.ProductName);
            Field(t => t.UnitPrice);
            Field(t => t.Package);
            Field(t => t.IsDiscontinued);

            Field<ListGraphType<OrderItemType>>(
              "orderItems",
              resolve: context =>
              {
                  var loader =
                      dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, OrderItem>(
                          "GetOrderItemsByProductId", orderItemRepository.GetForProducts);
                  return loader.LoadAsync(context.Source.Id);
              });

        }
    }
}
