using System.Windows;
using BLL;
using Microsoft.Extensions.DependencyInjection;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            ServicesHolder.Collection.ConfigurateBLLService(@"Data Source=data.sqlite3;");
            ServicesHolder.Provider = ServicesHolder.Collection.BuildServiceProvider();
            var c = ServicesHolder.Provider.GetService<BLL.Interfaces.IStoreService>();
        }
    }
}
