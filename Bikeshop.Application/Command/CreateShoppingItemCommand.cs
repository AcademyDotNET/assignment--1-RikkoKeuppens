using Bikeshop.Application.ViewModel;
using Domain.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.Command
{
    public class CreateShoppingItemCommand : IRequest<int>
    {
        public ShoppingItemVM ShoppingItem { get; set; }

        public CreateShoppingItemCommand(ShoppingItemVM newShoppingItem)
        {
            ShoppingItem = newShoppingItem;
        }
    }
}

    
