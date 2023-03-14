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
    public class ShowProductByIdQueryHandler : IRequestHandler<ShowProductByIdQuery, ProductVM>
    {
        IShopContext _context;

        public ShowProductByIdQueryHandler(IShopContext context)
        {
            _context = context;
        }

        public async Task<ProductVM> Handle(ShowProductByIdQuery request, CancellationToken cancellationToken)
        {
            var myProduct = await _context.Products.Where(p => p.Id == request.Id).SingleAsync();
            ProductVM vm = new ProductVM() { Id = myProduct.Id, Name = myProduct.Name, Price = myProduct.Price};
            return vm;
        }
    }
}
