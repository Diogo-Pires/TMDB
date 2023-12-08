namespace AppSpace.Application.Cinema.Dtos
{
    public class BillboardSuggestionDTO
    {
        public int WeekNumber { get; set; }
        public List<CinemaRoomsDTO> CinemaRooms { get; set; }
    }
}
