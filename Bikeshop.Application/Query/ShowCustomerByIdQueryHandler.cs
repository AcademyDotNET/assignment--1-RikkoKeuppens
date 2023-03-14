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
    public class ShowCustomerByIdQueryHandler : IRequestHandler<ShowCustomerByIdQuery, CustomerVM>
    {
        IShopContext _context;

        public ShowCustomerByIdQueryHandler(IShopContext context)
        {
            _context = context;
        }

        public async Task<CustomerVM> Handle(ShowCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Where(p => p.Id == request.Id).SingleAsync();
            CustomerVM vm = new CustomerVM() { Id = customer.Id, IdentityUser = customer.IdentityUser, UserName = customer.UserName };
            return vm;
        }
    }
}
