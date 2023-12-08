using AppSpace.Application.Cinema.Dtos;
using AppSpace.Application.Movies.Dtos;

namespace AppSpace.Application.Cinema.Interfaces
{
    public interface ICinemaService
    {
        Task<BillboardSuggestionDTO> GetBillboardSuggestionAsync(DateTime period, short numberOfScreens, bool basedOnSuccessfullyFilmInCity);
        Task<List<BillboardSuggestionDTO>> GetIntelligentBillboardSuggestionAsync(DateTime startDateTime,
                                                                                  DateTime endDateTime,
                                                                                  short numberOfScreensBigRooms,
                                                                                  short numberOfScreensSmallRooms,
                                                                                  bool basedOnSuccessfullyFilmInCity);
        Task<List<MovieDTO>> GetRecommendedUpcomingMoviesByRateAndGenreAsync(DateTime startDate, decimal rate, string genre, bool basedOnSuccessfullyFilmInCity);
    }
}