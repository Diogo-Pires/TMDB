using AppSpace.Application.Movies.Dtos;
using AppSpace.Application.Movies.Interfaces;
using AppSpace.Domain.Movie.Repositories;

namespace AppSpace.Application.Movies.Services
{
    public class DBMovieSourceForIntelligentBillboardService : IMovieSourceForIntelligentBillboardService
    {
        private readonly IMovieRepository _movieRepository;
        public bool isBasedOnSuccessfullyFilmInCity { get => true; }

        public DBMovieSourceForIntelligentBillboardService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieAndTitleDTO>> GetMostSuccessfullMoviesAsync(short currentState = 0) =>
            (await _movieRepository.GetMostSuccessfullMoviesAsync())
             .Select(x => new MovieAndTitleDTO(x.Id, x.Title))    
            .ToList();
    }
}