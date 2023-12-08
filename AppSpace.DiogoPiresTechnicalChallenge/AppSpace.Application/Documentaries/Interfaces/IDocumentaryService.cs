using AppSpace.Application.Documentaries.Dtos;

namespace AppSpace.Application.Documentaries.Interfaces
{
    public interface IDocumentaryService
    {
        Task<List<DocumentaryDTO>> GetAllRecommendedDocumentariesBasedOnTopicsAsync(string[] topics);
    }
}