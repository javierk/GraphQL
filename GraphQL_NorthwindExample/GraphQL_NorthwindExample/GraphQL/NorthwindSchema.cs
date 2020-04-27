using GraphQL.Types;
using GraphQL;

namespace GraphQL_NorthwindExample.Api.GraphQL
{
    public class NorthwindSchema : Schema
    {
        public NorthwindSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<NorthwindQuery>();
            Mutation = resolver.Resolve<NorthwindMutation>();
        }
    }
}
