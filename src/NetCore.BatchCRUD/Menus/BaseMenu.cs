using Microsoft.Extensions.Logging;

namespace NetCore.BatchCRUD.Menus
{
    public class BaseMenu<T> where T : class
    {
        protected readonly ILogger<T> _logger;
        public BaseMenu(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }
    }
}
