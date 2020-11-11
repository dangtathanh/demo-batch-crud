using Microsoft.Extensions.Logging;
using NetCore.BatchCRUD.Infrastructures.Constans;
using NetCore.BatchCRUD.Infrastructures.Contexts;
using NetCore.BatchCRUD.Infrastructures.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace NetCore.BatchCRUD.Infrastructures.Repositories
{
    public class BookUpdateRepository : BaseBookRepository<BookCreationRepository>, IBookUpdateRepository
    {
        public BookUpdateRepository(BookContext context, ILoggerFactory loggerFactory)
            : base(context, loggerFactory)
        {
        }

        public async Task<int> UpdateManyAsync(DateTime updateDate, BookStatus status)
        {
            var result = await _context.Books.Where(x => x.UpdatedOn > updateDate).UpdateAsync(x => new Book { Status = (int)status });
            return result;
        }
    }
}
