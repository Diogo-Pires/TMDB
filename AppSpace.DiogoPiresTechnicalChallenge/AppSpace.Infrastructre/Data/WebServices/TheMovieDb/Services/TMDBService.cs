using AppSpace.Infrastructure.Data.WebServices.TheMovieDb.Interfaces;
using System.Net;
using System.Net.Http.Headers;

namespace AppSpace.Infrastructure.Data.WebServices.TheMovieDb.Services
{
    public class TMDBService : ITMDBService
    {
        //TODO: Those below should go to a configuration file and be grabbed using a singleton
        const string CLIENT_NAME = "TMDB";
        const string TOKEN_BEARER = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI1OGE4MjRjZjc3NWE2NDJmYjMxZDkzOTc4NGQ0N2Q2ZSIsInN1YiI6IjVhMmFiODk4MGUwYTI2NGNiZTEyNGM1NCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.u2gC9D8mIhL64y-bgh8Q9CP5IViX7B3aoIYU8B0iLW4";
        private readonly HttpClient _httpClient;

        public TMDBService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(CLIENT_NAME);
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TOKEN_BEARER);
        }

        public async Task<string> GetAsync(string partialUrl)
        {
            var response = await _httpClient.GetAsync(partialUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new WebException();
        }
    }
}
