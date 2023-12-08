namespace AppSpace.Application.Movies.Dtos
{
    public class MovieAndTitleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public MovieAndTitleDTO(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
