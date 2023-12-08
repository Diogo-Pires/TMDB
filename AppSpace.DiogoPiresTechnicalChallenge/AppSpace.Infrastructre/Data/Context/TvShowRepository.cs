using AppSpace.Domain.TvShows.Entities;
using AppSpace.Domain.TvShows.Repositories;

namespace AppSpace.Infrastructure.Data.Context
{
    public class TvShowRepository : ITvShowRepository
    {
        private readonly AppDbContext _appDbContext;

        public TvShowRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<List<TvShow>> GetAllTimeRecommendedTvShowsByTagsAndOrGenresAsync(string[] tags, string[] genres)
        {
            throw new NotImplementedException();
        }
    }
}