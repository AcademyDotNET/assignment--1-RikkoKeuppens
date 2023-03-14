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
    public class ShowAllProductsQueryHandler : IRequestHandler<ShowAllProductsQuery, ListProductVM>
    {
        IShopContext _context;

        public ShowAllProductsQueryHandler(IShopContext context)
        {
            _context = context;
        }

        public async Task<ListProductVM> Handle(ShowAllProductsQuery request, CancellationToken cancellationToken)
        {
            var allProducts = await _context.Products.ToListAsync();

            ListProductVM vm = new ListProductVM();
            //map
            foreach (var product in allProducts)
            {
                vm.Products.Add(new ProductVM() { Id = product.Id, Name = product.Name, Price = product.Price});
            }

            return vm;
        }
    }
}
