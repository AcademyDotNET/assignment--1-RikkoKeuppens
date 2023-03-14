using Bikeshop.Application.Command;
using Bikeshop.Application.Query;
using Bikeshop.Application.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using BikeWebshop.Application.Interfaces;

namespace BikeShop.Controllers
{
    public class ProductController : Controller
    {
        IMediator _mediator;
        IShopContext _context;
        public ProductController(IMediator mediator, IShopContext shopContext)
        {
            _mediator = mediator;
            _context = shopContext;
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
            var user_id = _context.Customers.FirstOrDefault();
            var shoppingBag = _context.ShoppingBags.Where(j => j.CustomerID == user_id.Id)
                  .OrderByDescending(a => a.Id)
                  .Select(p => p).FirstOrDefault();
            shoppingItem.ShoppingBagID = shoppingBag.Id;
            var command = new CreateShoppingItemCommand(shoppingItem);
            await _mediator.Send(command);

            return LocalRedirect("/Product");
        }

        public async Task<IActionResult> Bag()
        {
            var query = new ShowShoppingBagInfoByIdQuery(1);
            var shoppingBagData = await _mediator.Send(query);
            return View(shoppingBagData);
        }
    }
}
