using AppSpace.Application.Movies.Dtos;

namespace AppSpace.Application.Movies.Interfaces
{
    public interface IMovieSourceForIntelligentBillboardService
    {
        public bool isBasedOnSuccessfullyFilmInCity { get; }
        public Task<List<MovieAndTitleDTO>> GetMostSuccessfullMoviesAsync(short currentState = 0);
    }
}
