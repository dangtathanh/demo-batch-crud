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

        public async Task<int> UpdateManyAsync(DateTime updateDate, Status fromStatus, Status toStatus)
        {
            //var result = await _context.Books.Join(_context.BookStatuses,
            //                                        x => x.Status,
            //                                        y => y.Id,
            //                                        (x, y) => x)
            //                            .Where(x => x.UpdatedOn > updateDate && x.Status == (int)fromStatus)
            //                            .UpdateAsync(x => new Book { Status = (int)toStatus });

            var result = await (from b in _context.Books 
                                join bs in _context.BookStatuses on b.Status equals bs.Id
                                where b.UpdatedOn > updateDate
                                    && bs.Id == (int)fromStatus
                                select b).UpdateAsync(x => new Book { Status = (int)toStatus });

            return result;
        }
    }
}
