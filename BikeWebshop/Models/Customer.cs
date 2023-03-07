using System.Collections;
using System.Collections.Generic;

namespace BikeWebshop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }

        public ICollection<ShoppingBag> Bags { get; set; }

        public Customer() { }

        public Customer(string name, string firstName)
        {
            Name = name;
            FirstName = firstName;
        }

    }
}
