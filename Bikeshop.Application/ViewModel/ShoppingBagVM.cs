using Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.ViewModel
{
    public class ShoppingBagVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ShoppingItem> Items { get; set; }

        public ShoppingBagVM(Customer customer, DateTime date) 
        {
            Items = new List<ShoppingItem>();
            Customer = customer;
            CustomerID = customer.Id;
            Date = date;
        }
    }
}
