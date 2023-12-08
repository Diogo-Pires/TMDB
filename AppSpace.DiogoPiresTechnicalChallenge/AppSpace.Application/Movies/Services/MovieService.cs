using AppSpace.Application.Movies.Dtos;
using AppSpace.Application.Movies.Interfaces;
using AppSpace.Domain.Movie.Repositories;

namespace AppSpace.Application.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieDTO>> GetAllTimeRecommendedMoviesByTagsAndOrGenresAsync(string[] tags, string[] genres)
        {
            var movies = await _movieRepository.GetAllTimeRecommendedMoviesByTagsAndOrGenresAsync(tags: tags, genres: genres);
            return movies.Select(movie => new MovieDTO { }).ToList();
        }

        public async Task<List<MovieDTO>> GetRecommendedUpcomingMoviesByTagsAndOrGenresAsync(DateTime startDate, string[] tags, string[] genres)
        {
            var movies = await _movieRepository.GetRecommendedUpcomingMoviesByTagsAndOrGenresAsync(startDate: startDate, tags: tags, genres: genres);
            return movies.Select(movie => new MovieDTO { }).ToList();
        }
    }
}