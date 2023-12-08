using AppSpace.Domain.TMDBMovie.Aggregates;
using AppSpace.Domain.TMDBMovie.Entities;
using AppSpace.Domain.TMDBMovie.Repositories;
using AppSpace.Infrastructure.Data.WebServices.TheMovieDb.Interfaces;
using Newtonsoft.Json;

namespace AppSpace.Infrastructure.Data.WebServices.TheMovieDb.Repositories
{
    public class TMDBMovieRepository : ITMDBMovieRepository
    {
        private readonly ITMDBService _tMDBService;

        public TMDBMovieRepository(ITMDBService tMDBService)
        {
            _tMDBService = tMDBService;
        }

        public async Task<List<TMDBMovie>> GetAllNonAdultsInEnglishWithoutVideoOrderByPopularityByPageAsync(short page)
        {
            //TODO: This one below should come from a configuration file.
            var partialUrl = $"?include_adult=false&include_video=false&language=en-US&page={page}&sort_by=popularity.desc";

            try
            {
                var results = await _tMDBService.GetAsync(partialUrl);
                if (string.IsNullOrWhiteSpace(results))
                {
                    return Enumerable.Empty<TMDBMovie>().ToList();
                }

                var resultObject = JsonConvert.DeserializeObject<TMDBMovieRoot>(results);
                if (resultObject is null || !resultObject.results.Any())
                {
                    return Enumerable.Empty<TMDBMovie>().ToList();
                }

                return resultObject.results;

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                //TODO: Log something in here
                throw;
            }
        }
    }
}