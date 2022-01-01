using AssetManager.Data.Config;
using AssetManager.Data.Factories;
using AssetManager.Services.Utility.MVVM.Navigation;
using AssetManager.Services.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace AssetManager
{

    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services => 
            {
                services.AddSingleton<AppViewModel>();
                services.AddTransient<AppDbContextFactory>();
                services.AddSingleton<Navigator>();
                services.AddSingleton<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<AppViewModel>()
                });
            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
           
        }
    }
}
