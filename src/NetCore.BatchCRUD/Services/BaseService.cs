using Microsoft.Extensions.Logging;

namespace NetCore.BatchCRUD.Services
{
    public class BaseService<T>
        where T : class
    {
        protected readonly ILogger _logger;
        public BaseService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }
    }
}
