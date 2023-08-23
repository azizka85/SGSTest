using Microsoft.Extensions.DependencyInjection;
using SGSTest.Services;
using System.Windows;

namespace SGSTest.WPF;

public partial class App : Application {
  private readonly ServiceProvider _serviceProvider;

  public App() {
    var services = new ServiceCollection();

    ConfigureServices(services);

    _serviceProvider = services.BuildServiceProvider();
  }

  private void ConfigureServices(ServiceCollection services) {
    services.AddSingleton<MainWindow>();
    
    services.AddSingleton<IDataService, DataService>();

    services.AddSingleton<IDataStorageService, DataStorageService>();
  }

  private void OnStartup(object sender, StartupEventArgs e) {
    var mainWindow = _serviceProvider.GetService<MainWindow>();

    mainWindow?.Show();
  }
}