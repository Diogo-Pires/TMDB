namespace AppSpace.API.Dtos
{
    public class BillboardSuggestionDTO
    {
        public int ScreenNumber { get; set; }
        public List<MoviePerWeekDTO> MoviesPerWeek { get; set; }
    }
}
