using AppSpace.Domain.TvShows.Entities;

namespace AppSpace.Domain.TvShows.Repositories
{
    public interface ITvShowRepository
    {
        Task<List<TvShow>> GetAllTimeRecommendedTvShowsByTagsAndOrGenresAsync(string[] tags, string[] genres);
    }
}