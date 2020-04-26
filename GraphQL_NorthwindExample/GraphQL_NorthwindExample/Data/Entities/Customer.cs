using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL_NorthwindExample.Api.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string FirstName { get; set; }
        [StringLength(40)]
        public string LastName { get; set; }
        [StringLength(40)]
        public string City { get; set; }
        [StringLength(40)]
        public string Country { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public List<Order> Orders { get; set; }
    }
}

