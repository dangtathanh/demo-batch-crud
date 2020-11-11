using System.Threading.Tasks;

namespace NetCore.BatchCRUD.Services
{
    public interface IBookCreationService
    {
        Task CreateManyAsync(int batchSize);
    }
}
