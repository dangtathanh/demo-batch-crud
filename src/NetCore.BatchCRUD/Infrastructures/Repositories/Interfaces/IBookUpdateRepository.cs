using NetCore.BatchCRUD.Infrastructures.Constans;
using System;
using System.Threading.Tasks;

namespace NetCore.BatchCRUD.Infrastructures.Repositories
{
    public interface IBookUpdateRepository
    {
        Task<int> UpdateManyAsync(DateTime updateDate, Status fromStatus, Status toStatus);
    }
}
