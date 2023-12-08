using AppSpace.Application.Documentaries.Dtos;
using AppSpace.Application.Documentaries.Interfaces;
using AppSpace.Domain.Documentaries.Repositories;

namespace AppSpace.Application.Documentaries.Services
{
    public class DocumentaryService : IDocumentaryService
    {
        private readonly IDocumentaryRepository _documentaryRepository;

        public DocumentaryService(IDocumentaryRepository documentaryRepository)
        {
            _documentaryRepository = documentaryRepository;
        }

        public async Task<List<DocumentaryDTO>> GetAllRecommendedDocumentariesBasedOnTopicsAsync(string[] topics)
        {
            var documentaries = await _documentaryRepository.GetAllRecommendedDocumentariesBasedOnTopicsAsync(topics: topics);
            return documentaries.Select(doc => new DocumentaryDTO { }).ToList();
        }
    }
}