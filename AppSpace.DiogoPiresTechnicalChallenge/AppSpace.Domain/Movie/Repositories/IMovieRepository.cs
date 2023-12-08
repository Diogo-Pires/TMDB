using AppSpace.Domain.Movie.ValueObjects;

namespace AppSpace.Domain.Movie.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Entities.Movie>> GetAllTimeRecommendedMoviesByTagsAndOrGenresAsync(string[] tags, string[] genres);
        Task<List<Entities.Movie>> GetRecommendedUpcomingMoviesByTagsAndOrGenresAsync(DateTime startDate, string[] tags, string[] genres);
        Task<List<SuccesfullMovie>> GetMostSuccessfullMoviesAsync();
    }
}