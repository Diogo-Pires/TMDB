using AppSpace.Application.TvShows.Dtos;

namespace AppSpace.Application.TvShows.Interfaces
{
    public interface ITvShowService
    {
        Task<List<TvShowDTO>> GetAllTimeRecommendedTvShowsByTagsAndOrGenresAsync(string[] tags, string[] genres);
    }
}