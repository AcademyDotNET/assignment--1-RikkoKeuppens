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
        RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,  IMediator mediator, IShopContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mediator = mediator;
            _context = context;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Register([FromForm] Login model)
        {
            var user = new IdentityUser { UserName = model.UserName, PasswordHash = model.Password };
            var result = _userManager.CreateAsync(user, model.Password);
            if (!result.Result.Succeeded)
            {
                return BadRequest(result.Result.Errors);
            }
            if (user.UserName == "Admin")
            {
                var admin = _roleManager.FindByNameAsync("Admin").Result;
                IdentityResult roleresult = await _userManager.AddToRoleAsync(user, admin.Name);
                Customer customer = new Customer(userName: user.UserName, identityUser: user, email: model.Email);
                var command = new CreateCustomerCommand(customer);
                await _mediator.Send(command);
                ShoppingBag shoppingBag = new ShoppingBag(command.Customer, DateTime.Now);
                var command2 = new CreateShoppingBagCommand(shoppingBag);
                await _mediator.Send(command2);
            }
            if (user.UserName != "Admin")
            {
                var customer = _roleManager.FindByNameAsync("Customer").Result;
                IdentityResult roleresult = await _userManager.AddToRoleAsync(user, customer.Name);
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
