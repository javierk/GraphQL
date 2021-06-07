using GraphQL_NorthwindExample.Api.Data;
using GraphQL_NorthwindExample.Api.Data.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_NorthwindExample.Api.Seed
{
    public class TestDataSeeder
    {
        public static void Initialize(NorthwindDbContext context, IServiceProvider services)
        {
            // Get a logger
            var logger = services.GetRequiredService<ILogger<TestDataSeeder>>();

            // Make sure the database is created
            context.Database.EnsureCreated();

            logger.LogInformation("clean database before seeding.");
            CleanDatabaseRecords(context);

            logger.LogInformation("Start seeding the database.");

            CreateCustomers(context);
            CreateSuppliers(context);
            CreateProducts(context);
            CreateOrders(context);
            CreateOrderItems(context);

            logger.LogInformation("Finished seeding the database.");
        }
        private static void CleanDatabaseRecords(NorthwindDbContext context)
        {
            CleanCustomers(context);
            CleanSuppliers(context);
            CleanProducts(context);
            CleanOrders(context);
            CleanOrderItems(context);
            context.SaveChanges();
        }
        private static void CleanCustomers(NorthwindDbContext context)
        {
            var records = context.Customer.ToList();

            foreach (var record in records)
            {
                context.Customer.Remove(record);
            }
        }
        private static void CleanSuppliers(NorthwindDbContext context)
        {
            var records = context.Supplier.ToList();

            foreach (var record in records)
            {
                context.Supplier.Remove(record);
            }
        }
        private static void CleanProducts(NorthwindDbContext context)
        {
            var records = context.Product.ToList();

            foreach (var record in records)
            {
                context.Product.Remove(record);
            }
        }
        private static void CleanOrders(NorthwindDbContext context)
        {
            var records = context.Order.ToList();

            foreach (var record in records)
            {
                context.Order.Remove(record);
            }
        }
        private static void CleanOrderItems(NorthwindDbContext context)
        {
            var records = context.OrderItem.ToList();

            foreach (var record in records)
            {
                context.OrderItem.Remove(record);
            }
        }
        private static void CreateCustomers(NorthwindDbContext context)
        {
            var customer1 = new Customer
            {
                Id = 1,
                FirstName = "Alfreds",
                LastName = "Futterkiste",
                City = "Berlin",
                Country = "Germany",
                Phone = "030-0074321",
            };

            var customer2 = new Customer
            {
                Id = 2,
                FirstName = "Ana",
                LastName = "Trujillo",
                City = "México D.F.",
                Country = "Mexico",
                Phone = "555-4729",
            };

            var customer3 = new Customer
            {
                Id = 3,
                FirstName = "Antonio",
                LastName = "Moreno",
                City = "México D.F.",
                Country = "Mexico",
                Phone = "555-3932",
            };

            var customer4 = new Customer
            {
                Id = 4,
                FirstName = "Frédérique",
                LastName = "Citeaux",
                City = "Strasbourg",
                Country = "France",
                Phone = "88.60.15.31",
            };

            var customer5 = new Customer
            {
                Id = 5,
                FirstName = "Thomas",
                LastName = "Hardy",
                City = "London",
                Country = "UK",
                Phone = "(171)555-6750",
            };

            var customer6 = new Customer
            {
                Id = 6,
                FirstName = "Hanna",
                LastName = "Moos",
                City = "Mannheim",
                Country = "Germany",
                Phone = "0621-08460",
            };

            var customer7 = new Customer
            {
                Id = 7,
                FirstName = "Diego",
                LastName = "Roel",
                City = "Madrid",
                Country = "Spain",
                Phone = "(91) 555 55 93",
            };

            var customer8 = new Customer
            {
                Id = 8,
                FirstName = "Folies",
                LastName = "Rancé",
                City = "Lille",
                Country = "France",
                Phone = "20.16.10.17",
            };

            var customer9 = new Customer
            {
                Id = 9,
                FirstName = "Carine",
                LastName = "Schmitt",
                City = "Nantes",
                Country = "France",
                Phone = "40.32.21.20",
            };

            var customer10 = new Customer
            {
                Id = 10,
                FirstName = "Peter",
                LastName = "Franken",
                City = "München",
                Country = "Germany",
                Phone = "089-0877451",
            };

            context.Customer.Add(customer1);
            context.Customer.Add(customer2);
            context.Customer.Add(customer3);
            context.Customer.Add(customer4);
            context.Customer.Add(customer5);
            context.Customer.Add(customer6);
            context.Customer.Add(customer7);
            context.Customer.Add(customer8);
            context.Customer.Add(customer9);
            context.Customer.Add(customer10);

            context.SaveChanges();
        }
        private static void CreateOrders(NorthwindDbContext context)
        {
            //TODO: ADD MORE ORDERS

            var order1 = new Order
            {
                Id = 1001,
                OrderDate = DateTime.Now.AddDays(-10),
                OrderNumber = "DEK938247",
                CustomerId = 1,
                TotalAmount= Convert.ToDecimal("546.12"),
            };

            context.Order.Add(order1);

            context.SaveChanges();
        }
        private static void CreateOrderItems(NorthwindDbContext context)
        {
            //TODO: ADD MORE ORDERS ITEMS

            var orderItem1 = new OrderItem
            {
                Id = 5498,
                OrderId = 1001,
                ProductId = 5498,
                Quantity = 3,
                UnitPrice = Convert.ToDecimal("93.13"),
            };

            context.OrderItem.Add(orderItem1);

            context.SaveChanges();
        }
        private static void CreateProducts(NorthwindDbContext context)
        {
            //TODO: ADD MORE PRODUCTS

            var product1 = new Product
            {
                Id = 5498,
                ProductName = "Mishi Kobe Niku",
                SupplierId = 9001,
                Package = "43-0394-VN",
                UnitPrice = Convert.ToDecimal("93.13"),
                IsDiscontinued = false
            };

            context.Product.Add(product1);

            context.SaveChanges();
        }
        private static void CreateSuppliers(NorthwindDbContext context)
        {
            //TODO: ADD MORE SUPPLIERS

            var supplier1 = new Supplier
            {
                Id = 9001,
                CompanyName = "Exotic Liquids",
                ContactName = "Charlotte Cooper",
                ContactTitle = "Purchasing Manager",
                City = "London",
                Country = "UK",
                Phone = "(171) 555 - 2222",
                Fax = null
            };

            context.Supplier.Add(supplier1);

            context.SaveChanges();
        }
    }
}
