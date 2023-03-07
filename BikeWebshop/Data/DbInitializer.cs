using BikeWebshop.Data;
using BikeWebshop.Models;
using System;
using System.Linq;

namespace Webshop.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ShopContext context)
        {
            context.Database.EnsureCreated();

			if (context.Products.Any())
			{
				return;
			}

			context.Customers.AddRange(new Customer("Keuppens", "Rikko"));

			context.Products.AddRange(
				new Product("BMX", 105.00),
				new Product("Mountainbike", 10.00),
				new Product("Bike 1", 105.00),
				new Product("Bike 2", 10.00),
				new Product("Bike 3", 125.00),
				new Product("Bike 4", 105.00),
				new Product("Bike 5", 5.00),
				new Product("Bike 6", 10.00),
				new Product("Bike 7", 105.00),
				new Product("Bike 8", 105.00),
				new Product("Bike 9", 105.00),
				new Product("Bike 10", 10.00),
				new Product("Bike 11", 125.00),
				new Product("Bike 12", 105.00),
				new Product("Bike 13", 105.00),
				new Product("Bike 14", 175.00),
				new Product("Bike 15", 10.00),
				new Product("Bike 16", 105.00),
				new Product("Bike 17", 175.00),
				new Product("Bike 18", 10.00)
			);

			context.SaveChanges();
		}
    }
}
