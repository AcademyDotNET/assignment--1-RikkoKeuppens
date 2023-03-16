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

namespace BikeShop.Controllers
{
    public class AdministratorController : Controller
    {
        IMediator _mediator;
        public AdministratorController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> NewBike()
        {
            return View();
        }

        public async Task<IActionResult> AddBike([FromForm] Product product)
        {
            if (product.CheckRegistration(product.RegistrationNumber))
            {
                var command = new CreateProductCommand(product);
                await _mediator.Send(command);
                return Redirect("/");
            }
            return Redirect("/Administrator/NewBike");
        }
    }
}
