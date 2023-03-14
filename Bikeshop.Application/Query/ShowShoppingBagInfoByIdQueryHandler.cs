using BikeWebshop.Application.Interfaces;
using Domain.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.Query
{
    public class ShowShoppingBagInfoByIdQueryHandler : IRequestHandler<ShowShoppingBagInfoByIdQuery, ShoppingBag>
    {
        IShopContext _context;

        public ShowShoppingBagInfoByIdQueryHandler(IShopContext context)
        {
            _context = context;
        }
        public async Task<ShoppingBag> Handle(ShowShoppingBagInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var shoppingBag = await _context.ShoppingBags.Where(s => s.Id == request.Id).Include(c => c.Customer).Include(s => s.Items).ThenInclude(p => p.Product).SingleAsync();
            ShoppingBag newShoppingBag = new ShoppingBag() { Id = shoppingBag.Id, Date = shoppingBag.Date, Customer = shoppingBag.Customer, Items = shoppingBag.Items, CustomerID = shoppingBag.CustomerID};
            return newShoppingBag;
        }
    }
}
