using Domain.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.Query
{
    public class ShowShoppingBagInfoByIdQuery : IRequest<ShoppingBag>
    {
        public int Id { get; set; }

        public ShowShoppingBagInfoByIdQuery(int id) { Id = id; }
    }
}
