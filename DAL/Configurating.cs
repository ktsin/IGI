using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class Configurating
    {
        public static void ConfigurateDALService(this IServiceCollection services, string connectionString)
        {
            services.
                AddDbContext<Repository.EFDataContext>(opt => opt.UseSqlite(connectionString)
                .UseLazyLoadingProxies());

            services
                .AddSingleton(typeof(DAL.Interfaces.EntityInterfaces.IStoreRepository),
                typeof(DAL.Entities.EFCore.StoreRepository));
        }
    }
}
