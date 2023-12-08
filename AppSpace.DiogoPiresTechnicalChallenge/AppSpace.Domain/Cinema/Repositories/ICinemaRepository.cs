namespace AppSpace.Domain.Cinema.Repositories
{
    public interface ICinemaRepository
    {
        Task<Entities.Cinema> GetCinemaByNameAsync(string name);
    }
}