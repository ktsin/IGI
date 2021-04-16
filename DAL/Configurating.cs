using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class Configurating
    {
        public static void ConfigurateDALService(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Repository.EFDataContext>(opt => opt.UseSqlite(connectionString).UseLazyLoadingProxies());
            services.AddScoped<Interfaces.EFCore.EFContextBasic, DAL.Repository.EFDataContext>();
            services.AddSingleton<Interfaces.EntityInterfaces.IStoreRepository, Entities.EFCore.StoreRepository>();
            services.AddSingleton<Interfaces.EntityInterfaces.IProductRepository, Entities.EFCore.ProductRepository>();
            services.AddSingleton<Interfaces.EntityInterfaces.IOrderRepository, Entities.EFCore.OrderRepository>();
            services.AddSingleton<Interfaces.EntityInterfaces.IUserRepository, Entities.EFCore.UserRepository>();
        }
    }
}
