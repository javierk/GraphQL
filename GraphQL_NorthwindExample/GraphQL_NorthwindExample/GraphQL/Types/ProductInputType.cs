using GraphQL.Types;

namespace GraphQL_NorthwindExample.Api.GraphQL.Types
{
    public class ProductInputType: InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "productInput";
            Field<NonNullGraphType<StringGraphType>>("productName");
            Field<NonNullGraphType<IntGraphType>>("supplierId");
            Field<StringGraphType>("package");
            Field<DecimalGraphType>("unitPrice");
            Field<NonNullGraphType<BooleanGraphType>>("isDiscontinued");
        }
       
    }
}
