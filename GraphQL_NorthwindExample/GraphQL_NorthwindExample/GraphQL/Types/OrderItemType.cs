using GraphQL.Types;
using GraphQL_NorthwindExample.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_NorthwindExample.Api.GraphQL.Types
{
    public class OrderItemType: ObjectGraphType<OrderItem>
    {
        public OrderItemType()
        {
            Field(t => t.Id);
            Field(t => t.UnitPrice);
            Field(t => t.Quantity);
            Field(t => t.ProductId);
            Field(t => t.OrderId);
        }
    }
}
