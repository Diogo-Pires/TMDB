namespace AppSpace.Domain.TMDBMovie.Aggregates
{
    public class TMDBMovieRoot
    {
        public int page { get; set; }
        public List<Entities.TMDBMovie> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}