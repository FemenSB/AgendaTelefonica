using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using AgendaTelefonica.Database;

namespace AgendaTelefonica
{
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<DatabaseService>();
            serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<DatabaseService>()?.EnsureDatabaseIsCreated();
        }
    }
}
