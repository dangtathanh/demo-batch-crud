using Microsoft.Extensions.Logging;
using NetCore.BatchCRUD.Infrastructures.Contexts;

namespace NetCore.BatchCRUD.Infrastructures.Repositories
{
    public class BaseBookRepository<T>
        where T : class
    {
        protected readonly BookContext _context;
        protected readonly ILogger _logger;
        public BaseBookRepository(BookContext context,
                                    ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<T>();
        }
    }
}
