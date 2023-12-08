namespace AppSpace.Domain.Genre.Aggregates
{
    public class MovieGenre
    {
        public int MovieId { get; private set; }
        public virtual Movie.Entities.Movie Movie { get; private set; }
        public int GenreId { get; private set; }
        public virtual Entities.Genre Genre { get; private set; }
    }
}