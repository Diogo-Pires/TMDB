namespace AppSpace.Domain.TMDBMovie.Repositories
{
    public interface ITMDBMovieRepository
    {
        Task<List<Entities.TMDBMovie>> GetAllNonAdultsInEnglishWithoutVideoOrderByPopularityByPageAsync(short page);
    }
}