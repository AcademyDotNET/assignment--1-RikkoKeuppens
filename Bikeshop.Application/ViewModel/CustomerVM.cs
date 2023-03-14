using Domain.Persistence;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.ViewModel
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public ICollection<ShoppingBag> Bags { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public CustomerVM(string userName, IdentityUser identityUser)
        {
            UserName = userName;
            IdentityUser = identityUser;
        }

        public CustomerVM()
        {
        }
    }
}
