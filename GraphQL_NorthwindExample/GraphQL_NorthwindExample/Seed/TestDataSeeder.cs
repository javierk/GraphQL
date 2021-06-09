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
            var order1 = new Order
            {
                Id = 1001,
                OrderDate = DateTime.Now.AddDays(-10),
                OrderNumber = "DEK938247",
                CustomerId = 1,
                TotalAmount= Convert.ToDecimal("546.12"),
            };

            var order2 = new Order
            {
                Id = 1002,
                OrderDate = DateTime.Now.AddDays(-8),
                OrderNumber = "DEK323497",
                CustomerId = 1,
                TotalAmount = Convert.ToDecimal("1749.00"),
            };

            var order3 = new Order
            {
                Id = 1003,
                OrderDate = DateTime.Now.AddDays(-3),
                OrderNumber = "TYL982475",
                CustomerId = 2,
                TotalAmount = Convert.ToDecimal("9863.21"),
            };

            var order4 = new Order
            {
                Id = 1004,
                OrderDate = DateTime.Now.AddDays(-20),
                OrderNumber = "PER458635",
                CustomerId = 3,
                TotalAmount = Convert.ToDecimal("789.34"),
            };

            var order5 = new Order
            {
                Id = 1005,
                OrderDate = DateTime.Now.AddDays(-30),
                OrderNumber = "MFJ587639",
                CustomerId = 3,
                TotalAmount = Convert.ToDecimal("412.02"),
            };

            var order6 = new Order
            {
                Id = 1006,
                OrderDate = DateTime.Now.AddDays(-10),
                OrderNumber = "JGF983564",
                CustomerId = 4,
                TotalAmount = Convert.ToDecimal("1289.34"),
            };

            var order7 = new Order
            {
                Id = 1007,
                OrderDate = DateTime.Now.AddDays(-9),
                OrderNumber = "DEK584444",
                CustomerId = 5,
                TotalAmount = Convert.ToDecimal("639.22"),
            };

            var order8 = new Order
            {
                Id = 1008,
                OrderDate = DateTime.Now.AddDays(-2),
                OrderNumber = "KKU893839",
                CustomerId = 6,
                TotalAmount = Convert.ToDecimal("98.58"),
            };

            var order9 = new Order
            {
                Id = 1009,
                OrderDate = DateTime.Now.AddDays(-1),
                OrderNumber = "EEG669332",
                CustomerId = 6,
                TotalAmount = Convert.ToDecimal("78.23"),
            };

            var order10 = new Order
            {
                Id = 1010,
                OrderDate = DateTime.Now.AddDays(-4),
                OrderNumber = "IKL782369",
                CustomerId = 7,
                TotalAmount = Convert.ToDecimal("419.36"),
            };

            var order11 = new Order
            {
                Id = 1011,
                OrderDate = DateTime.Now.AddDays(-6),
                OrderNumber = "VVL730270",
                CustomerId = 8,
                TotalAmount = Convert.ToDecimal("360.03"),
            };

            var order12 = new Order
            {
                Id = 1012,
                OrderDate = DateTime.Now.AddDays(-90),
                OrderNumber = "AAI890190",
                CustomerId = 10,
                TotalAmount = Convert.ToDecimal("1208.96"),
            };

            context.Order.Add(order1);
            context.Order.Add(order2);
            context.Order.Add(order3);
            context.Order.Add(order4);
            context.Order.Add(order5);
            context.Order.Add(order6);
            context.Order.Add(order7);
            context.Order.Add(order8);
            context.Order.Add(order9);
            context.Order.Add(order10);
            context.Order.Add(order11);
            context.Order.Add(order12);

            context.SaveChanges();
        }
        private static void CreateOrderItems(NorthwindDbContext context)
        {
            var orderItem1 = new OrderItem
            {
                Id = 50001,
                OrderId = 1001,
                ProductId = 5401,
                Quantity = 3,
                UnitPrice = Convert.ToDecimal("93.13"),
            };

            var orderItem2 = new OrderItem
            {
                Id = 50002,
                OrderId = 1002,
                ProductId = 5402,
                Quantity = 2,
                UnitPrice = Convert.ToDecimal("69.12"),
            };

            var orderItem3 = new OrderItem
            {
                Id = 50003,
                OrderId = 1003,
                ProductId = 5403,
                Quantity = 1,
                UnitPrice = Convert.ToDecimal("7.36"),
            };

            var orderItem4 = new OrderItem
            {
                Id = 50004,
                OrderId = 1004,
                ProductId = 5404,
                Quantity = 9,
                UnitPrice = Convert.ToDecimal("856.32"),
            };

            var orderItem5 = new OrderItem
            {
                Id = 50005,
                OrderId = 1005,
                ProductId = 5411,
                Quantity = 8,
                UnitPrice = Convert.ToDecimal("256.39"),
            };

            var orderItem6 = new OrderItem
            {
                Id = 50006,
                OrderId = 1006,
                ProductId = 5406,
                Quantity = 45,
                UnitPrice = Convert.ToDecimal("890.00"),
            };

            var orderItem7 = new OrderItem
            {
                Id = 50007,
                OrderId = 1007,
                ProductId = 5411,
                Quantity = 1,
                UnitPrice = Convert.ToDecimal("56.00"),
            };

            var orderItem8 = new OrderItem
            {
                Id = 50008,
                OrderId = 1008,
                ProductId = 5402,
                Quantity = 8,
                UnitPrice = Convert.ToDecimal("698.00"),
            };

            var orderItem9 = new OrderItem
            {
                Id = 50009,
                OrderId = 1009,
                ProductId = 5415,
                Quantity = 2,
                UnitPrice = Convert.ToDecimal("124.98"),
            };

            var orderItem10 = new OrderItem
            {
                Id = 50010,
                OrderId = 1010,
                ProductId = 5413,
                Quantity = 8,
                UnitPrice = Convert.ToDecimal("778.33"),
            };

            var orderItem11 = new OrderItem
            {
                Id = 50011,
                OrderId = 1011,
                ProductId = 5414,
                Quantity = 9,
                UnitPrice = Convert.ToDecimal("747.11"),
            };

            var orderItem12 = new OrderItem
            {
                Id = 50012,
                OrderId = 1012,
                ProductId = 5405,
                Quantity = 4,
                UnitPrice = Convert.ToDecimal("47.44"),
            };

            var orderItem13 = new OrderItem
            {
                Id = 50013,
                OrderId = 1001,
                ProductId = 5412,
                Quantity = 1,
                UnitPrice = Convert.ToDecimal("10.00"),
            };

            var orderItem14 = new OrderItem
            {
                Id = 50014,
                OrderId = 1002,
                ProductId = 5411,
                Quantity = 3,
                UnitPrice = Convert.ToDecimal("194.00"),
            };

            var orderItem15 = new OrderItem
            {
                Id = 50015,
                OrderId = 1004,
                ProductId = 5402,
                Quantity = 11,
                UnitPrice = Convert.ToDecimal("723.12"),
            };

            var orderItem16 = new OrderItem
            {
                Id = 50016,
                OrderId = 1003,
                ProductId = 5412,
                Quantity = 14,
                UnitPrice = Convert.ToDecimal("793.31"),
            };

            var orderItem17 = new OrderItem
            {
                Id = 50017,
                OrderId = 1002,
                ProductId = 5417,
                Quantity = 6,
                UnitPrice = Convert.ToDecimal("112.88"),
            };

            var orderItem18 = new OrderItem
            {
                Id = 50018,
                OrderId = 1007,
                ProductId = 5416,
                Quantity = 2,
                UnitPrice = Convert.ToDecimal("98.66"),
            };

            context.OrderItem.Add(orderItem1);
            context.OrderItem.Add(orderItem2);
            context.OrderItem.Add(orderItem3);
            context.OrderItem.Add(orderItem4);
            context.OrderItem.Add(orderItem5);
            context.OrderItem.Add(orderItem6);
            context.OrderItem.Add(orderItem7);
            context.OrderItem.Add(orderItem8);
            context.OrderItem.Add(orderItem9);
            context.OrderItem.Add(orderItem10);
            context.OrderItem.Add(orderItem11);
            context.OrderItem.Add(orderItem12);
            context.OrderItem.Add(orderItem13);
            context.OrderItem.Add(orderItem14);
            context.OrderItem.Add(orderItem15);
            context.OrderItem.Add(orderItem16);
            context.OrderItem.Add(orderItem17);
            context.OrderItem.Add(orderItem18);

            context.SaveChanges();
        }
        private static void CreateProducts(NorthwindDbContext context)
        {
            var product1 = new Product
            {
                Id = 5401,
                ProductName = "Mishi Kobe Niku",
                SupplierId = 9001,
                Package = "43-0394-VN",
                UnitPrice = Convert.ToDecimal("93.13"),
                IsDiscontinued = false
            };

            var product2 = new Product
            {
                Id = 5402,
                ProductName = "Chai",
                SupplierId = 9001,
                Package = "43-0333-VN",
                UnitPrice = Convert.ToDecimal("12.03"),
                IsDiscontinued = false
            };

            var product3 = new Product
            {
                Id = 5403,
                ProductName = "Aniseed Syrup",
                SupplierId = 9002,
                Package = "93-TY/23",
                UnitPrice = Convert.ToDecimal("11.54"),
                IsDiscontinued = false
            };

            var product4 = new Product
            {
                Id = 5404,
                ProductName = "Chef Anton's Cajun Seasoning",
                SupplierId = 9002,
                Package = "TY03234558L",
                UnitPrice = Convert.ToDecimal("40.01"),
                IsDiscontinued = false
            };

            var product5 = new Product
            {
                Id = 5405,
                ProductName = "Grandma's Boysenberry Spread",
                SupplierId = 9002,
                Package = "Y-98324-VA",
                UnitPrice = Convert.ToDecimal("239.10"),
                IsDiscontinued = false
            };

            var product6 = new Product
            {
                Id = 5406,
                ProductName = "Northwoods Cranberry Sauce",
                SupplierId = 9003,
                Package = "9038543",
                UnitPrice = Convert.ToDecimal("65.84"),
                IsDiscontinued = false
            };

            var product7 = new Product
            {
                Id = 5407,
                ProductName = "Queso Cabrales",
                SupplierId = 9005,
                Package = "QSO2304985",
                UnitPrice = Convert.ToDecimal("63.78"),
                IsDiscontinued = false
            };

            var product8 = new Product
            {
                Id = 5408,
                ProductName = "Queso Manchego La Pastora",
                SupplierId = 9005,
                Package = "QSO234872",
                UnitPrice = Convert.ToDecimal("12.11"),
                IsDiscontinued = false
            };

            var product9 = new Product
            {
                Id = 5409,
                ProductName = "Tofu",
                SupplierId = 9006,
                Package = "13-0IER-112",
                UnitPrice = Convert.ToDecimal("2.54"),
                IsDiscontinued = false
            };

            var product10 = new Product
            {
                Id = 5410,
                ProductName = "Genen Shouyu",
                SupplierId = 9006,
                Package = "32-1ETT-906",
                UnitPrice = Convert.ToDecimal("6.32"),
                IsDiscontinued = true
            };

            var product11 = new Product
            {
                Id = 5411,
                ProductName = "Konbu",
                SupplierId = 9006,
                Package = "98-1ETR-233",
                UnitPrice = Convert.ToDecimal("12.78"),
                IsDiscontinued = false
            };

            var product12 = new Product
            {
                Id = 5412,
                ProductName = "Alice Mutton",
                SupplierId = 9007,
                Package = "324087DFF",
                UnitPrice = Convert.ToDecimal("193.98"),
                IsDiscontinued = false
            };

            var product13 = new Product
            {
                Id = 5413,
                ProductName = "Carnarvon Tigers",
                SupplierId = 9007,
                Package = "9093432GHJD",
                UnitPrice = Convert.ToDecimal("8353.09"),
                IsDiscontinued = false
            };

            var product14 = new Product
            {
                Id = 5414,
                ProductName = "Teatime Chocolate Biscuits",
                SupplierId = 9008,
                Package = "29834734B",
                UnitPrice = Convert.ToDecimal("56.89"),
                IsDiscontinued = false
            };

            var product15 = new Product
            {
                Id = 5415,
                ProductName = "Sir Rodney's Marmalade",
                SupplierId = 9008,
                Package = "87234634C",
                UnitPrice = Convert.ToDecimal("102.63"),
                IsDiscontinued = false
            };

            var product16 = new Product
            {
                Id = 5416,
                ProductName = "Sir Rodney's Scones",
                SupplierId = 9008,
                Package = "1234873C",
                UnitPrice = Convert.ToDecimal("241.23"),
                IsDiscontinued = false
            };

            var product17 = new Product
            {
                Id = 5417,
                ProductName = "Boston Crab Meat",
                SupplierId = 9008,
                Package = "0234734D",
                UnitPrice = Convert.ToDecimal("657.44"),
                IsDiscontinued = true
            };

            var product18 = new Product
            {
                Id = 5418,
                ProductName = "Gula Malacca",
                SupplierId = 9009,
                Package = "DF/2834764",
                UnitPrice = Convert.ToDecimal("5.32"),
                IsDiscontinued = false
            };

            var product19 = new Product
            {
                Id = 5419,
                ProductName = "Rogede sild",
                SupplierId = 9009,
                Package = "TF/298343",
                UnitPrice = Convert.ToDecimal("87.11"),
                IsDiscontinued = false
            };

            context.Product.Add(product1);
            context.Product.Add(product2);
            context.Product.Add(product3);
            context.Product.Add(product4);
            context.Product.Add(product5);
            context.Product.Add(product6);
            context.Product.Add(product7);
            context.Product.Add(product8);
            context.Product.Add(product9);
            context.Product.Add(product10);
            context.Product.Add(product11);
            context.Product.Add(product12);
            context.Product.Add(product13);
            context.Product.Add(product14);
            context.Product.Add(product15);
            context.Product.Add(product16);
            context.Product.Add(product17);
            context.Product.Add(product18);
            context.Product.Add(product19);


            context.SaveChanges();
        }
        private static void CreateSuppliers(NorthwindDbContext context)
        {
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

            var supplier2 = new Supplier
            {
                Id = 9002,
                CompanyName = "New Orleans Cajun Delights",
                ContactName = "Shelley Burke",
                ContactTitle = "Order Administrator",
                City = "New Orleans",
                Country = "USA",
                Phone = "(100) 555-4822",
                Fax = "(100) 555 - 4826"
            };

            var supplier3 = new Supplier
            {
                Id = 9003,
                CompanyName = "Grandma Kelly's Homestead",
                ContactName = "Regina Murphy",
                ContactTitle = "Sales Representative",
                City = "Ann Arbor",
                Country = "USA",
                Phone = "(313) 555-5735",
                Fax = "(313) 555-3349"
            };

            var supplier4 = new Supplier
            {
                Id = 9004,
                CompanyName = "Tokyo Traders",
                ContactName = "Yoshi Nagase",
                ContactTitle = "Marketing Manager",
                City = "Tokyo",
                Country = "Japan",
                Phone = "(03) 3555-5011",
                Fax = null
            };

            var supplier5 = new Supplier
            {
                Id = 9005,
                CompanyName = "Cooperativa de Quesos 'Las Cabras'",
                ContactName = "Antonio del Valle Saavedra",
                ContactTitle = "Export Administrator",
                City = "Oviedo",
                Country = "Spain",
                Phone = "(98) 598 76 54",
                Fax = null
            };

            var supplier6 = new Supplier
            {
                Id = 9006,
                CompanyName = "Mayumi's",
                ContactName = "Mayumi Ohno",
                ContactTitle = "Marketing Representative",
                City = "Osaka",
                Country = "Japan",
                Phone = "(06) 431-7877",
                Fax = null
            };

            var supplier7 = new Supplier
            {
                Id = 9007,
                CompanyName = "Pavlova, Ltd.",
                ContactName = "Ian Devling",
                ContactTitle = "Marketing Manager",
                City = "Melbourne",
                Country = "Australia",
                Phone = "(03) 444-2343",
                Fax = "(03) 444-6588"
            };

            var supplier8 = new Supplier
            {
                Id = 9008,
                CompanyName = "Specialty Biscuits, Ltd.",
                ContactName = "Peter Wilson",
                ContactTitle = "Sales Representative",
                City = "Manchester",
                Country = "UK",
                Phone = "(161) 555-4448",
                Fax = null
            };

            var supplier9 = new Supplier
            {
                Id = 9009,
                CompanyName = "Refrescos Americanas LTDA",
                ContactName = "Carlos Diaz",
                ContactTitle = "Marketing Manager",
                City = "Sao Paulo",
                Country = "Brazil",
                Phone = "(11) 555 4640",
                Fax = null
            };

            var supplier10 = new Supplier
            {
                Id = 9010,
                CompanyName = "Formaggi Fortini s.r.l.",
                ContactName = "Elio Rossi",
                ContactTitle = "Sales Representative",
                City = "Ravenna",
                Country = "Italy",
                Phone = "(0544) 60323",
                Fax = "(0544) 60603"
            };

            context.Supplier.Add(supplier1);
            context.Supplier.Add(supplier2);
            context.Supplier.Add(supplier3);
            context.Supplier.Add(supplier4);
            context.Supplier.Add(supplier5);
            context.Supplier.Add(supplier6);
            context.Supplier.Add(supplier7);
            context.Supplier.Add(supplier8);
            context.Supplier.Add(supplier9);
            context.Supplier.Add(supplier10);

            context.SaveChanges();
        }
    }
}
