using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Persistence
{
    public class ShoppingBag
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ShoppingItem> Items { get; set; }

        public ShoppingBag() { }

        public ShoppingBag(Customer customer, DateTime date)
        {
            Items = new List<ShoppingItem>();
            Customer = customer;
            CustomerID = customer.Id;
            Date = date;
        }

        public void AddItem(ShoppingItem shoppingItem)
        {
            Items.Add(shoppingItem);
        }
    }
}
