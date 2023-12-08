namespace AppSpace.Domain.TvShows.Entities
{
    public class TvShow : Media.Entities.Media
    {
        public short NumberOfSeasons { get; set; }
        public int NumberOfEpisodes { get; set; }
        public bool HasConcluded { get; set; }
    }
}