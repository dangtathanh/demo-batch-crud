using Microsoft.Extensions.Logging;
using NetCore.BatchCRUD.Infrastructures.Constans;
using NetCore.BatchCRUD.Infrastructures.Repositories;
using System;
using System.Threading.Tasks;

namespace NetCore.BatchCRUD.Services
{
    public class BookUpdateService : BaseService<BookUpdateService>, IBookUpdateService
    {
        private readonly IBookUpdateRepository _bookUpdateRepository;
        public BookUpdateService(IBookUpdateRepository bookUpdateRepository,
                                    ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            _bookUpdateRepository = bookUpdateRepository;
        }

        public async Task UpdateManyAsync(DateTime beforeDate, Status fromStatus, Status toStatus)
        {
            _logger.LogInformation($"Start updating records which UpdatedOn less than '{beforeDate.ToString("yyyy-MM-dd")}' from status '{fromStatus}' to status '{toStatus}'...");
            var affected = await _bookUpdateRepository.UpdateManyAsync(beforeDate, fromStatus, toStatus);
            _logger.LogInformation($"{affected} records were updated!");
        }
    }
}
