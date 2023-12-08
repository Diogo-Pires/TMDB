using AppSpace.Application.TvShows.Dtos;
using AppSpace.Application.TvShows.Interfaces;
using AppSpace.Domain.TvShows.Repositories;

namespace AppSpace.Application.TvShows.Services
{
    public class TvShowService : ITvShowService
    {
        private readonly ITvShowRepository _tvShowRepository;

        public TvShowService(ITvShowRepository tvShowRepository)
        {
            _tvShowRepository = tvShowRepository;
        }

        public async Task<List<TvShowDTO>> GetAllTimeRecommendedTvShowsByTagsAndOrGenresAsync(string[] tags, string[] genres)
        {
            var tvShows = await _tvShowRepository.GetAllTimeRecommendedTvShowsByTagsAndOrGenresAsync(tags: tags, genres: genres);
            return tvShows.Select(movie => new TvShowDTO { }).ToList();
        }
    }
}