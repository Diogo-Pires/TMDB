using AppSpace.Domain.Documentaries.Entities;
using AppSpace.Domain.Documentaries.Repositories;

namespace AppSpace.Infrastructure.Data.Context
{
    public class DocumentaryRepository : IDocumentaryRepository
    {
        private readonly AppDbContext _appDbContext;

        public DocumentaryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<List<Documentary>> GetAllRecommendedDocumentariesBasedOnTopicsAsync(string[] topics)
        {
            throw new NotImplementedException();
        }
    }
}