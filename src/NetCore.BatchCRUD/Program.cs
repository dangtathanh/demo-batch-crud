using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetCore.BatchCRUD.Infrastructures.Contexts;
using NetCore.BatchCRUD.Infrastructures.Extenstions;
using NetCore.BatchCRUD.Services;
using Serilog;
using System;
using System.Threading.Tasks;

namespace NetCore.BatchCRUD
{
    class Program
    {
        private static string _env { get; set; }
        private static IConfiguration _configuration { get; set; }
        private static IServiceProvider _serviceProvider { set; get; }
        private static ILogger<Program> _logger { set; get; }
        static async Task Main(string[] args)
        {
            try
            {
                // Setup environment & services
                ConfigureConfigurations();
                ConfigureServices();

                // Setup country selection
                while (true)
                {
                    var _batchSize = 1000000;
                    _logger.LogInformation($"Start creating {_batchSize} books...");
                    var _bookCreation = _serviceProvider.GetService<IBookCreationService>();
                    await _bookCreation.CreateManyAsync(_batchSize);
                    _logger.LogInformation($"{_batchSize} books created completely!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Somethings happened!");
            }
        }

        private class Factory : IDesignTimeDbContextFactory<BookContext>
        {
            public BookContext CreateDbContext(string[] args)
                => _serviceProvider.GetService<BookContext>();
        }


        private static IServiceCollection ConfigureServices()
        {
            var logTemplate = "[{Timestamp:yyyyMMdd-HH:mm:ss} {Level:u3}] {Message:lj}{Data:lj}{NewLine}{Exception}";
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Information()
                                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Information)
                                .WriteTo.Console(outputTemplate: logTemplate)
                                .CreateLogger();

            var services = new ServiceCollection();
            ConfigureConfigurations();
            services.AddSingleton(_configuration);

            // Logger
            services.AddLogging(configure => configure.AddSerilog());

            services.InjectBaseDataRequires(_configuration);

            _serviceProvider = services.BuildServiceProvider(true);
            _logger = _serviceProvider.GetService<ILogger<Program>>();

            return services;
        }

        private static void ConfigureConfigurations()
        {
            _configuration = new ConfigurationBuilder()
                                    .AddJsonFile($"appsettings.json",
                                                 optional: true,
                                                 reloadOnChange: true)
                                    .Build();
        }
    }
}
