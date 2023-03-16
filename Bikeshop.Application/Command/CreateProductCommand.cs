using Domain.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.Command
{
    public class CreateProductCommand : IRequest<int>
    {
        public Product Product { get; set; }

        public CreateProductCommand(Product product)
        {
            Product = product;
        }
    }
}
