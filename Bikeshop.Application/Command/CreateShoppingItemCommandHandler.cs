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
    public class CreateShoppingItemCommandHandler : IRequestHandler<CreateShoppingItemCommand, int>
    {
        IShopContext _context;

        public CreateShoppingItemCommandHandler(IShopContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateShoppingItemCommand request, CancellationToken cancellationToken)
        {
            ShoppingItem newShoppingItem = new ShoppingItem() { Id = request.ShoppingItem.Id, Quantity = request.ShoppingItem.Quantity, ProductID = request.ShoppingItem.ProductID, ShoppingBagID = request.ShoppingItem.ShoppingBagID, Product = request.ShoppingItem.Product, ShoppingBag = request.ShoppingItem.ShoppingBag };

            _context.ShoppingItems.Add(newShoppingItem);
            return await _context.SaveAsync(cancellationToken);
        }
    }
}
