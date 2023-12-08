namespace AppSpace.Infrastructure.Data.WebServices.TheMovieDb.Interfaces
{
    public interface ITMDBService
    {
        Task<string> GetAsync(string partialUrl);
    }
}