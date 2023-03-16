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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        IShopContext _context;

        public CreateProductCommandHandler(IShopContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product() { Id = request.Product.Id, Name = request.Product.Name, Price = request.Product.Price, RegistrationNumber = request.Product.RegistrationNumber };
            var query = _context.Products.Add(product);
            return await _context.SaveAsync(cancellationToken);
        }
    }
}
