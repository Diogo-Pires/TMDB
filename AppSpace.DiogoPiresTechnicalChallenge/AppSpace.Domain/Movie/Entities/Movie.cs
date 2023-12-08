namespace AppSpace.Domain.Movie.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string OriginalTitle { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string OriginalLanguage { get; private set; }
        public bool Adult { get; private set; }

        public virtual List<Genre.Entities.Genre> Genres { get; private set; }
        public virtual List<Sessions.Entities.Session> Sessions { get; private set; }
    }
}