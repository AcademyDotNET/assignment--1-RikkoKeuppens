using Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.ViewModel
{
    public class ShoppingItemVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public int ShoppingBagID { get; set; }

        public Product Product { get; set; }
        public ShoppingBag ShoppingBag { get; set; }
    }
}
