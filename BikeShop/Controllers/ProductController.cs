using Bikeshop.Application.Command;
using Bikeshop.Application.Query;
using Bikeshop.Application.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using BikeWebshop.Application.Interfaces;
using Domain.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace BikeShop.Controllers
{
    public class ProductController : Controller
    {
        IMediator _mediator;
        IShopContext _context;
        UserManager<IdentityUser> _userManager;
        private readonly ILogger<ProductController> _logger;
        public ProductController(UserManager<IdentityUser> userManager, IMediator mediator, IShopContext shopContext, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _context = shopContext;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var query = new ShowAllProductsQuery();
            var products = await _mediator.Send(query);
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var query = new ShowProductByIdQuery(id);
            ViewData["product"] = await _mediator.Send(query);
            return View();
        }

        public async Task<IActionResult> Shop([Bind("ProductID,Quantity")] ShoppingItemVM shoppingItem)
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var query = new ShowCustomerByUserIdQuery(userId);
            var customer = await _mediator.Send(query);
            var shoppingBag = _context.ShoppingBags.Where(j => j.CustomerID == customer.Id)
                  .OrderByDescending(a => a.Id)
                  .Select(p => p).FirstOrDefault();
            shoppingItem.ShoppingBagID = shoppingBag.Id;
            var command = new CreateShoppingItemCommand(shoppingItem);
            await _mediator.Send(command);
            _logger.LogDebug("item to shoppingbag");

            return LocalRedirect("/Product");
        }

        public async Task<IActionResult> Bag()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var query = new ShowShoppingBagInfoByIdQuery(1);
            var shoppingBagData = await _mediator.Send(query);
            ViewData["Discount"] = getDiscount(shoppingBagData);
            return View(shoppingBagData);
        }

        public double getDiscount(ShoppingBag shoppingBag)
        {
            double productCount = 0;
            foreach(ShoppingItem shoppingItem in shoppingBag.Items) 
            {
                productCount += shoppingItem.Quantity;
            }
            switch (productCount)
            {
                case < 3:
                    return 0;
                case >= 3 and < 6:
                    return 5;
                case >= 6:
                    return 10;
            }
            return 0;
        }
    }
}
