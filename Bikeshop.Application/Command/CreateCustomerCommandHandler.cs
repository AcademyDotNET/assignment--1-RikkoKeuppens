using BikeWebshop.Application.Interfaces;
using Domain.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.Command
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        IShopContext _context;

        public CreateCustomerCommandHandler(IShopContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new Customer() { Id = request.Customer.Id, UserName = request.Customer.UserName, IdentityUser = request.Customer.IdentityUser};
            var query = _context.Customers.Add(customer);
            return await _context.SaveAsync(cancellationToken);
        }
    }
}
