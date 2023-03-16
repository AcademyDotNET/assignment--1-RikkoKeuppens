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
    public class CreateShoppingBagCommandHandler : IRequestHandler<CreateShoppingBagCommand, int>
    {
        IShopContext _context;

        public CreateShoppingBagCommandHandler(IShopContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateShoppingBagCommand request, CancellationToken cancellationToken)
        {
            ShoppingBag shoppingBag = new ShoppingBag() { Id = request.ShoppingBag.Id, Customer = request.ShoppingBag.Customer, Date = request.ShoppingBag.Date};
        
            _context.ShoppingBags.Add(shoppingBag);
            return await _context.SaveAsync(cancellationToken);
        }
    }
}
