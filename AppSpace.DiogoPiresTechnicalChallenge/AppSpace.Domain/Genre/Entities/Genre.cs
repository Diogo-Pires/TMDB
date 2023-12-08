namespace AppSpace.Domain.Genre.Entities
{
    public class Genre
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public virtual List<Movie.Entities.Movie> Movies { get; private set; }
    }
}
