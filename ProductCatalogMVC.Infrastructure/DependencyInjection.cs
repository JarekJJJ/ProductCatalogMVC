using Microsoft.Extensions.DependencyInjection;
using ProductCatalogMVC.Domain.Interface;
using ProductCatalogMVC.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IWarehouseItemRepository, WarehouseItemRepository>();
            services.AddTransient<IWarehouseRepository, WarehouseRepository>();
            return services;
        }
    }
}
