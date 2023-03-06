using BikeWebshop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BikeWebshop.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            Product product1 = new Product(1, "Mountainbike", 105.00);
            Product product2 = new Product(2, "BMX", 82.00);
            Product product3 = new Product(3, "Normal bike", 54.00);
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);

            return View(products);
        }

        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
