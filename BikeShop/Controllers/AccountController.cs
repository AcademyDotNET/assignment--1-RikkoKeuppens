using Bikeshop.Application.Command;
using Bikeshop.Application.Query;
using Bikeshop.Application.ViewModel;
using BikeWebshop.Application.Interfaces;
using Domain.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult RegisterPage()
        {
            return View();
        }

        IShopContext _context;
        IMediator _mediator;
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMediator mediator, IShopContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mediator = mediator;
            _context = context;
        }
        public async Task<IActionResult> Register([FromForm] Login model)
        {
            var user = new IdentityUser { UserName = model.UserName, PasswordHash = model.Password };
            var result = _userManager.CreateAsync(user, model.Password);
            if (!result.Result.Succeeded)
            {
                return BadRequest(result.Result.Errors);
            }
            else
            {
                Customer customer = new Customer(userName: user.UserName, identityUser: user);
                var command = new CreateCustomerCommand(customer);
                ShoppingBag shoppingBag = new ShoppingBag(command.Customer, DateTime.Now);
                var command2 = new CreateShoppingBagCommand(shoppingBag);
                await _mediator.Send(command2);
            }
            return RedirectToAction("LoginPage", "Account");
        }

        public async Task<IActionResult> Login([FromForm] Login login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, true, false);

            if (result.Succeeded)
            {
                return LocalRedirect("/Product");
            }
            return LocalRedirect("");
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return Ok();
        }
    }
}
