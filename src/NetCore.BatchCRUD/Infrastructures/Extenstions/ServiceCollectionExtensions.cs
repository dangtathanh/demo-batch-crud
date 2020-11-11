using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.BatchCRUD.Infrastructures.Contexts;
using NetCore.BatchCRUD.Infrastructures.Repositories;
using NetCore.BatchCRUD.Services;

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
            services.AddTransient<IBookCreationRepository, BookCreationRepository>();
            services.AddTransient<IBookUpdateRepository, BookUpdateRepository>();

            // Services
            services.AddTransient<IBookCreationService, BookCreationService>();
            services.AddTransient<IBookUpdateService, BookUpdateService>();


            return services;
        }
    }
}
