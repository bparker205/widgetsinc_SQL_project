using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace widgetsinc_SQL_project
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
#if DEBUG
                .AddJsonFile("appsettings.Debug.json")
#else
                .AddJsonFile("appsettings.Release.json")
#endif
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            var productRepo = new ProductRepository(connString);

            // Converts table to list then prints rows to console
            List<Product> products = productRepo.GetProducts();

            foreach (Product product in products)
            {
                Console.WriteLine($"{product.id} | " +
                    $"{product.brand_id} | " +
                    $"{product.description} | " +
                    $"{product.status_id} | " +
                    $"{product.catagory_id}\n");
            }

        }
    }
}
