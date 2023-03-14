using Bikeshop.Application.ViewModel;
using Domain.Persistence;
using MediatR;

namespace Bikeshop.Application.Command
{
    public class CreateShoppingBagCommand : IRequest<int>
    {
        public ShoppingBag ShoppingBag { get; set; }

        public CreateShoppingBagCommand(ShoppingBag shoppingBag)
        {
            ShoppingBag = shoppingBag;
        }
    }
}
