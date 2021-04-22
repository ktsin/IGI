using BLL;
using Microsoft.Extensions.DependencyInjection;

namespace WpfApp
{
    public static class Configure
    {
        public static void ConfigurateUIService(this IServiceCollection services, string connectionString)
        {
            services.ConfigurateBLLService(connectionString);
            services.AddScoped<MainWindowModel>();
            services.AddScoped<MainWindowViewModel>();
        }
    }
}
