using System.Collections.Generic;

namespace BikeWebshop.Models
{
    public class ProductModel
    {
        public List<Product> Products { get; set; }
        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }
    }
}
