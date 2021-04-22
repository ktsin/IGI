using BLL;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            ServicesHolder.Collection.ConfigurateUIService(@"Data Source=data.sqlite3;");
            ServicesHolder.Provider = ServicesHolder.Collection.BuildServiceProvider();
        }
    }
}
