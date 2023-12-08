using AppSpace.Domain.Cinema.Entities;
using AppSpace.Domain.Movie.Entities;
using AppSpace.Domain.Movie.Repositories;
using AppSpace.Domain.Movie.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AppSpace.Infrastructure.Data.Context
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _appDbContext;

        public MovieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<List<Movie>> GetAllTimeRecommendedMoviesByTagsAndOrGenresAsync(string[] tags, string[] genres)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SuccesfullMovie>> GetMostSuccessfullMoviesAsync()
        {
            try
            {
                var roomsAndTotalSoldSeats = (
                    from session in _appDbContext.Session
                    group session by new { session.RoomId, session.MovieId } into s
                    select new
                    {
                        RoomId = s.FirstOrDefault().RoomId,
                        MovieId = s.FirstOrDefault().MovieId,
                        SeatsSolds = s.Sum(x => x.SeatsSold)
                    }
                );

                return await (
                    from g in roomsAndTotalSoldSeats
                    join movie in _appDbContext.Movie
                    on g.MovieId equals movie.Id
                    join room in _appDbContext.Room
                    on g.RoomId equals room.Id
                    join cinema in _appDbContext.Cinema
                    on room.CinemaId equals cinema.Id
                    join city in _appDbContext.City
                    on cinema.CityId equals city.Id
                    select new SuccesfullMovie()
                    {
                        Id = movie.Id,
                        Title = movie.OriginalTitle,
                        SeatsByPopulationRatio = city.Population / g.SeatsSolds
                    }
                ).OrderBy(x => x.SeatsByPopulationRatio)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                //TODO: Log something in here
                throw;
            }
        }

        public Task<List<Movie>> GetRecommendedUpcomingMoviesByTagsAndOrGenresAsync(DateTime startDate, string[] tags, string[] genres)
        {
            throw new NotImplementedException();
        }
    }
}