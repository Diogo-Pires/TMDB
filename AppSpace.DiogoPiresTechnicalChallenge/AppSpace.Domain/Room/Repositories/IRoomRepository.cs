using AppSpace.Domain.Room.ValueObjects;

namespace AppSpace.Domain.Movie.Repositories
{
    public interface IRoomRepository
    {
        Task<List<RoomsPerCinemaAndSize>> GetRoomsByNumberOfScreensAsync(short numberOfScreensBigRooms, short numberOfScreensSmallRooms);
    }
}