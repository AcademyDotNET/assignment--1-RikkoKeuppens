using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Persistence
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public ICollection<ShoppingBag> Bags { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public Customer(string userName, IdentityUser identityUser, string email)
        {
            UserName = userName;
            IdentityUser = identityUser;
            Email = email;
        }

        public Customer()
        {
        }
    }
}
