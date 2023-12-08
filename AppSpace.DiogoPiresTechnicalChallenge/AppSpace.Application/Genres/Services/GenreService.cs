using AppSpace.Application.Genres.Dtos;
using AppSpace.Application.Genres.Interfaces;
using AppSpace.Domain.Genre.Repositories;

namespace AppSpace.Application.Genres.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<List<GenreDTO>> GetAllAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            return genres.Select(movie => new GenreDTO { }).ToList();
        }

        public async Task<bool> IsGenresValidAsync(string[] genres)
        {
            throw new NotImplementedException();
        }
    }
}