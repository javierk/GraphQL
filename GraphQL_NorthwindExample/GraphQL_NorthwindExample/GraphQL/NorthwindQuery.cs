using GraphQL_NorthwindExample.Api.GraphQL.Types;
using GraphQL_NorthwindExample.Api.Repositories;
using GraphQL.Types;

namespace GraphQL_NorthwindExample.Api.GraphQL
{
    public class NorthwindQuery : ObjectGraphType
    {
        public NorthwindQuery(CustomerRepository customerRepository,
                              OrderRepository orderRepository, 
                              SupplierRepository supplierRepository,
                              ProductRepository productRepository,
                              OrderItemRepository orderItemRepository)
        {
            Field<ListGraphType<CustomerType>>(
                "customers",
                resolve: context => customerRepository.GetAll()
            );

            Field<ListGraphType<OrderType>>(
               "orders",
               resolve: context => orderRepository.GetAll()
            );

            Field<ListGraphType<SupplierType>>(
               "suppliers",
               resolve: context => supplierRepository.GetAll()
            );

            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetAll()
            );

            Field<ListGraphType<OrderItemType>>(
                "orderItems",
                resolve: context => orderItemRepository.GetAll()
            );

            Field<CustomerType>(
                "customer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return customerRepository.GetOne(id);
                }
            );

            Field<SupplierType>(
                "supplier",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return supplierRepository.GetOne(id);
                }
            );

            Field<OrderType>(
                "order",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return orderRepository.GetOne(id);
                }
            );

            Field<ListGraphType<SupplierType>>(
                "suppliersByCountry",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>>
                { Name = "country" }),
                resolve: context =>
                {
                    var country = context.GetArgument<string>("country");
                    return supplierRepository.GetForCountry(country);
                }
            );
        }
    }
}
