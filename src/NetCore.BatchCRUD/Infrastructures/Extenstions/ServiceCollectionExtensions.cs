using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.BatchCRUD.Infrastructures.Contexts;

namespace NetCore.BatchCRUD.Infrastructures.Extenstions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection InjectBaseDataRequires(this IServiceCollection services, IConfiguration configuration)
        {
            // Settings
            var settings = new AppSettings();
            ConfigurationBinder.Bind(configuration, settings);

            // Data Contexts
            services.AddDbContext<BookContext>(
                options => options.UseMySql(settings.ConnectionString),
                ServiceLifetime.Singleton,
                ServiceLifetime.Singleton);

            // Repositories

            // Services


            return services;
        }
    }
}
