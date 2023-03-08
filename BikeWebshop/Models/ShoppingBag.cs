using System;
using System.Collections;
using System.Collections.Generic;

namespace BikeWebshop.Models
{
    public class ShoppingBag
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ShoppingItem> Items { get; set; }

        public ShoppingBag() { }

        public ShoppingBag(Customer customer) 
        { 
            Customer = customer;
            Items = new List<ShoppingItem>();
            Date = DateTime.Now;
        }

        public ShoppingBag(Customer customer, ShoppingItem shoppingItem)
        {
            Customer = customer;
            Items = new List<ShoppingItem>();
            Items.Add(shoppingItem);
            Date = DateTime.Now;
        }

        public void AddItem(ShoppingItem shoppingItem)
        {
            Items.Add(shoppingItem);
        }
    }
}
