using System.Collections;
using System.Collections.Generic;

namespace Domain.Persistence
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string RegistrationNumber { get; set; }

        public Product() { }
        
        public Product( string name, double price, string registrationNumber)
        {
            Name = name;
            Price = price;
            RegistrationNumber = registrationNumber;
        }

        public bool CheckRegistration(string registrationNumber)
        {
            if (registrationNumber.Substring(0, 3) == "ABC" && registrationNumber.Length == 8)
            {
                return true;
            }
            return false;
        }

    }
}
