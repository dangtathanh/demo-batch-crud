using Bogus;
using Microsoft.Extensions.Logging;
using NetCore.BatchCRUD.Infrastructures.Models;
using NetCore.BatchCRUD.Infrastructures.Repositories;
using System.Threading.Tasks;

namespace NetCore.BatchCRUD.Services
{
    public class BookCreationService : BaseService<BookCreationService>, IBookCreationService
    {
        private readonly IBookCreationRepository _bookCreationRepository;
        public BookCreationService(IBookCreationRepository bookCreationRepository,
                                    ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            _bookCreationRepository = bookCreationRepository;
        }

        public async Task CreateManyAsync(int batchSize)
        {
            var books = new Faker<Book>()
                                .RuleFor(x => x.Id, _ => 0)
                                .RuleFor(x => x.Name, f => f.Random.Words(5))
                                .RuleFor(x => x.Status, f => f.Random.Number(0, 2))
                                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                                .RuleFor(x => x.UpdatedOn, f => f.Date.Past())
                                .Generate(batchSize);
            await _bookCreationRepository.CreateManyAsync(books);
        }
    }
}
