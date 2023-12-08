using AppSpace.Domain.Cinema.Entities;
using AppSpace.Domain.Cinema.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppSpace.Infrastructure.Data.Context
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly AppDbContext _appDbContext;

        public CinemaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Cinema> GetCinemaByNameAsync(string name) =>
            await _appDbContext.Cinema.FirstOrDefaultAsync(x => x.Name == name);
    }
}