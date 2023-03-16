using Bikeshop.Application.ViewModel;
using BikeWebshop.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.Query
{
    public class ShowCustomerByUserIdQueryHandler : IRequestHandler<ShowCustomerByUserIdQuery, CustomerVM>
    {
        IShopContext _context;

        public ShowCustomerByUserIdQueryHandler(IShopContext context)
        {
            _context = context;
        }
        public async Task<CustomerVM> Handle(ShowCustomerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Where(p => p.IdentityUser.Id == request.UserId).SingleAsync();
            CustomerVM vm = new CustomerVM() { Id = customer.Id, IdentityUser = customer.IdentityUser, UserName = customer.UserName, Email = customer.Email };
            return vm;
        }
    }
}
