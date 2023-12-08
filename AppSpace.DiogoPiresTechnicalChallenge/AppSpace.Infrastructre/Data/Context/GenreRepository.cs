using AppSpace.Domain.Genre.Entities;
using AppSpace.Domain.Genre.Repositories;

namespace AppSpace.Infrastructure.Data.Context
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _appDbContext;

        public GenreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<List<Genre>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}