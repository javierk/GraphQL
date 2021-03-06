﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_NorthwindExample.Api.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
