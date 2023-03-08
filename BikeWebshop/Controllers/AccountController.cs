using BikeWebshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BikeWebshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromForm] Login model)
        {
            var user = new IdentityUser { UserName = model.UserName, PasswordHash = model.Password };
            var result = _userManager.CreateAsync(user, model.Password);
            if (!result.Result.Succeeded)
            {
                return BadRequest(result.Result.Errors);
            }
            else
            {
                var customer = new Customer(user.UserName, user);
                var shoppingBag = new ShoppingBag(customer);
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm] Login login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, true, false);

            if (result.Succeeded)
            {
                return LocalRedirect("/Products");
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
