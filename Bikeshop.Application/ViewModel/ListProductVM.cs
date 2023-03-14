using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.ViewModel
{
    public class ListProductVM
    {
        public ListProductVM() 
        {
            Products = new List<ProductVM>();
        }
        public List<ProductVM> Products { get; set; }
    }
}
