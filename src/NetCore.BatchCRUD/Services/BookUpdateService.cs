using Microsoft.Extensions.Logging;
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

        public async Task UpdateManyAsync(DateTime beforeDate)
        {
            await _bookUpdateRepository.UpdateManyAsync(beforeDate, Infrastructures.Constans.BookStatus.Damaging);
        }
    }
}
