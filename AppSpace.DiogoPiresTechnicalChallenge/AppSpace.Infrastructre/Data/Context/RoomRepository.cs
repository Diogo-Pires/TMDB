using AppSpace.Domain.Movie.Repositories;
using AppSpace.Domain.Room.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AppSpace.Infrastructure.Data.Context
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _appDbContext;

        public RoomRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<RoomsPerCinemaAndSize>> GetRoomsByNumberOfScreensAsync(short numberOfScreensBigRooms, short numberOfScreensSmallRooms)
        {
            try
            {
                var roomsAndSizes = await _appDbContext.Room
                    .GroupBy(x => new { x.Size, x.CinemaId})
                    .Select(x => new RoomsPerCinemaAndSize
                    {
                        Size = x.Key.Size,
                        CinemaId = x.Key.CinemaId,
                        NumberOfScreens = x.Count()
                    })
                    .ToListAsync();

                return roomsAndSizes.Where(x => (x.Size == RoomSizes.Big.ToString() &&
                                                x.NumberOfScreens >= numberOfScreensBigRooms) ||
                                                (x.Size == RoomSizes.Small.ToString() &&
                                                x.NumberOfScreens >= numberOfScreensSmallRooms))
                                    .ToList();
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