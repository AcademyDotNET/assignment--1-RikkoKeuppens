using BikeWebshop.Data;
using BikeWebshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeWebshop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopContext _context;
        public ProductsController(ShopContext context) { _context = context; }

        public  IActionResult Index()
        {
            return View(GetProducts(1));
        }

        [HttpPost]
        public IActionResult Index(int currentPageIndex)
        {
            return View(GetProducts(currentPageIndex));
        }

        private ProductModel GetProducts(int currentPage)
        {
            int maxRows = 10;
            ProductModel productModel = new ProductModel();

            productModel.Products = (from product in _context.Products
                                       select product)
                        .OrderBy(product => product.Id)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows).ToList();

            double pageCount = (double)((decimal)_context.Products.Count() / maxRows);
            productModel.PageCount = (int)Math.Ceiling(pageCount);

            productModel.CurrentPageIndex = currentPage;

            return productModel;
        }

        public IActionResult Details(int id)
        {
            ViewData["product"] = _context.Products.FirstOrDefault(p => p.Id == id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Shop([Bind("ProductID,Product,Quantity")] ShoppingItem shoppingItem)
        {
            var product = _context.Products.Where(p => p.Id == shoppingItem.ProductID).FirstOrDefault();
            shoppingItem.Product = product;
            Customer customer = _context.Customers.FirstOrDefault();
            var shoppingBag = _context.ShoppingBags.Where(x => x.CustomerID == customer.Id).OrderByDescending(x => x.Date).First();
            if (shoppingBag == null)
            {
                ShoppingBag newShoppingBag = new ShoppingBag(customer, shoppingItem);
                shoppingItem.ShoppingBagID = newShoppingBag.Id;
                _context.Add(shoppingBag);
            }
            else
            {
                shoppingItem.ShoppingBagID = shoppingBag.Id;
                _context.Update(shoppingBag);
            }
            if (ModelState.IsValid)
            {
                _context.Add(shoppingItem);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }

        public IActionResult ShoppingBag()
        {
            Customer customer = _context.Customers.FirstOrDefault();
            ShoppingBag shoppingBag = _context.ShoppingBags.Where(x => x.CustomerID == customer.Id).OrderByDescending(x => x.Date).First();
            List<ShoppingItem> shoppingItems = _context.ShoppingItems.Where(x => x.ShoppingBagID == shoppingBag.Id).Include(x => x.Product).ToList();
            ShoppingItemList shoppingItemList = new ShoppingItemList();
            shoppingItemList.ShoppingItems = shoppingItems;
            return View(shoppingItemList);
        }
    }
}

