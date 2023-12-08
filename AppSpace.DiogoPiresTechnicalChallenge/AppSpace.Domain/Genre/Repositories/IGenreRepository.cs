
namespace AppSpace.Domain.Genre.Repositories
{
    public interface IGenreRepository
    {
        Task<List<Entities.Genre>> GetAllAsync();
    }
}