using DataAccess;
using DataAccess.Implementation;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementation;
using Services.Interface;
using System.Collections;

namespace Services.Helper
{
    public static class DIModule
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString) 
        {
            services.AddDbContext<LiquorStoreDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IBeverageRepository, BeverageRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IBeverageService, BeverageService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
