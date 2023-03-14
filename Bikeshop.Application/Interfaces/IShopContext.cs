using Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeWebshop.Application.Interfaces
{
    public interface IShopContext
    {
        public DbSet<Product> Products { get; }
        public DbSet<ShoppingItem> ShoppingItems { get; }
        public DbSet<ShoppingBag> ShoppingBags { get; }
        public DbSet<Customer> Customers { get; }

        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
