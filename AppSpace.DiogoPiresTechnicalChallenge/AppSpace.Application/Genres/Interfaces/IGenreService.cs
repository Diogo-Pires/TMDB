using AppSpace.Application.Genres.Dtos;

namespace AppSpace.Application.Genres.Interfaces
{
    public interface IGenreService
    {
        Task<List<GenreDTO>> GetAllAsync();
        Task<bool> IsGenresValidAsync(string[] genres);
    }
}
