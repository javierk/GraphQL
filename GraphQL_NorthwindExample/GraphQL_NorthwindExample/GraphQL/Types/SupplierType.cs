using GraphQL_NorthwindExample.Api.Data.Entities;
using GraphQL.Types;
using GraphQL.DataLoader;
using GraphQL_NorthwindExample.Api.Repositories;

namespace GraphQL_NorthwindExample.Api.GraphQL.Types
{
    public class SupplierType: ObjectGraphType<Supplier>
    {
        public SupplierType(ProductRepository productRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.CompanyName);
            Field(t => t.ContactName);
            Field(t => t.ContactTitle);
            Field(t => t.City);
            Field(t => t.Country);
            Field(t => t.Phone);
            Field(t => t.Fax);

            Field<ListGraphType<ProductType>>(
              "products",
              resolve: context =>
              {
                  var loader =
                      dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Product>(
                          "GetProductsBySupplierId", productRepository.GetForSuppliers);
                  return loader.LoadAsync(context.Source.Id);
              });
        }
    }
}
