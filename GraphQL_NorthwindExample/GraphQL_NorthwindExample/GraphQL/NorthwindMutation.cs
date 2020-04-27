using GraphQL.Types;
using GraphQL_NorthwindExample.Api.Data.Entities;
using GraphQL_NorthwindExample.Api.GraphQL.Types;
using GraphQL_NorthwindExample.Api.Repositories;

namespace GraphQL_NorthwindExample.Api.GraphQL
{
    public class NorthwindMutation : ObjectGraphType
    {
        public NorthwindMutation(ProductRepository productRepository)
        {
            FieldAsync<ProductType>(
                "createProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }),
                resolve: async context =>
                {
                    var prod = context.GetArgument<Product>("product");
                    return await context.TryAsyncResolve(
                        async c => await productRepository.AddProduct(prod));
                });
        }
    }
}
