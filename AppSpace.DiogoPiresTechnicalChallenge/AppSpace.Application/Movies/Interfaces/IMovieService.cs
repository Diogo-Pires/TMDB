using AppSpace.Application.Movies.Dtos;

namespace AppSpace.Application.Movies.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieDTO>> GetAllTimeRecommendedMoviesByTagsAndOrGenresAsync(string[] tags, string[] genres);
        Task<List<MovieDTO>> GetRecommendedUpcomingMoviesByTagsAndOrGenresAsync(DateTime startDate, string[] tags, string[] genres);
    }
}