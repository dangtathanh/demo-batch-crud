using NetCore.BatchCRUD.Infrastructures.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.BatchCRUD.Infrastructures.Repositories
{
    public interface IBookCreationRepository
    {
        Task<IEnumerable<Book>> CreateManyAsync(IEnumerable<Book> books);
    }
}
