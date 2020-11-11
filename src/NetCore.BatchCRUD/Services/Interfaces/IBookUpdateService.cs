using System;
using System.Threading.Tasks;

namespace NetCore.BatchCRUD.Services
{
    public interface IBookUpdateService
    {
        Task UpdateManyAsync(DateTime beforeDate);
    }
}
