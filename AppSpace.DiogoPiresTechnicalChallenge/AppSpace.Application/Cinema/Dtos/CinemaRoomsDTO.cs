namespace AppSpace.Application.Cinema.Dtos
{
    public class CinemaRoomsDTO
    {
        public int CinemaId { get; set; }
        public string RoomSize { get; set; }
        public List<string> RoomsMovies { get; set; }
    }
}
