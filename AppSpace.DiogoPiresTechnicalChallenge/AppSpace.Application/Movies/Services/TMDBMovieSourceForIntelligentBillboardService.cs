using AppSpace.Application.Movies.Dtos;
using AppSpace.Application.Movies.Interfaces;
using AppSpace.Domain.TMDBMovie.Repositories;

namespace AppSpace.Application.Movies.Services
{
    public class TMDBMovieSourceForIntelligentBillboardService : IMovieSourceForIntelligentBillboardService
    {
        private readonly ITMDBMovieRepository _tMDBMovieRepository;

        public bool isBasedOnSuccessfullyFilmInCity { get => false; }

        public TMDBMovieSourceForIntelligentBillboardService(ITMDBMovieRepository tMDBMovieRepository)
        {
            _tMDBMovieRepository = tMDBMovieRepository;
        }

        public async Task<List<MovieAndTitleDTO>> GetMostSuccessfullMoviesAsync(short currentState = 1) =>
            (await _tMDBMovieRepository.GetAllNonAdultsInEnglishWithoutVideoOrderByPopularityByPageAsync(currentState))
             .Select(x => new MovieAndTitleDTO(x.id, x.title))
            .ToList();
    }
}
