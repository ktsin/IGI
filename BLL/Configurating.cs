using Microsoft.Extensions.DependencyInjection;
using DAL;

namespace BLL
{
    public static class Configurating
    {
        public static void ConfigurateBLLService(this IServiceCollection services, string connectionString)
        {
            services.ConfigurateDALService(connectionString);
            services.AddScoped<BLL.Interfaces.IOrderService,   BLL.Services.OrderService>();
            services.AddScoped<BLL.Interfaces.IProductService, BLL.Services.ProductService>();
            services.AddScoped<BLL.Interfaces.IStoreService,   BLL.Services.StoreService>();
            services.AddScoped<BLL.Interfaces.IUserService,    BLL.Services.UserService>();
        }
    }
}
