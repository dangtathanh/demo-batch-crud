using Microsoft.Extensions.Logging;
using NetCore.BatchCRUD.Infrastructures.Contexts;
using NetCore.BatchCRUD.Infrastructures.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.BatchCRUD.Infrastructures.Repositories
{
    public class BookCreationRepository : BaseBookRepository<BookCreationRepository>, IBookCreationRepository
    {
        public BookCreationRepository(BookContext context, ILoggerFactory loggerFactory)
            : base(context, loggerFactory)
        {
        }

        public async Task<IEnumerable<Book>> CreateManyAsync(IEnumerable<Book> books)
        {
            await _context.BulkInsertAsync(typeof(Book), books);
            return books;
        }
    }
}
