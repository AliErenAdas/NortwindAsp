using Base.Repositories;
using DatabaseFirst.IRepositories;
using DatabaseFirst.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class EfContextRepo
    {

        public static void AddScopeEf(this IServiceCollection services)
        {
            services.AddDbContext<NORTHWNDContext>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IEmployeeRepository, EmployeeRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IShipperRepository, ShipperRepository>()
            .AddScoped<ISupplierRepository, SupplierRepository>();

        }

    }
}
