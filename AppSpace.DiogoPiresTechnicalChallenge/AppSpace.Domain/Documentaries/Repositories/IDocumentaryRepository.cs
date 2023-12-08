using AppSpace.Domain.Documentaries.Entities;

namespace AppSpace.Domain.Documentaries.Repositories
{
    public interface IDocumentaryRepository
    {
        Task<List<Documentary>> GetAllRecommendedDocumentariesBasedOnTopicsAsync(string[] topics);
    }
}