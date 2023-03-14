using BikeShop.Persistence;
using BikeWebshop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPersistence(this IServiceCollection services, IConfiguration Configuration) 
        {
            services.AddDbContext<ShopContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppDb")));

            services.AddScoped<IShopContext>(provider => provider.GetService<ShopContext>());



            return services;
        }
    }
}
