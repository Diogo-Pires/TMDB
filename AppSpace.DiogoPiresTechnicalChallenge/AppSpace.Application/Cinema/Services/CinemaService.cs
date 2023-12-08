using AppSpace.Application.Cinema.Dtos;
using AppSpace.Application.Cinema.Interfaces;
using AppSpace.Application.Movies.Dtos;
using AppSpace.Application.Movies.Interfaces;
using AppSpace.Domain.Movie.Repositories;

namespace AppSpace.Application.Cinema.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IList<IMovieSourceForIntelligentBillboardService> _movieSourceForIntelligentBillboardService;

        public CinemaService(IRoomRepository roomRepository, IList<IMovieSourceForIntelligentBillboardService> movieSourceForIntelligentBillboardService)
        {
            _roomRepository = roomRepository;
            _movieSourceForIntelligentBillboardService = movieSourceForIntelligentBillboardService;
        }

        public Task<BillboardSuggestionDTO> GetBillboardSuggestionAsync(DateTime period, short numberOfScreens, bool basedOnSuccessfullyFilmInCity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BillboardSuggestionDTO>> GetIntelligentBillboardSuggestionAsync(DateTime startDateTime,
                                                                                               DateTime endDateTime,
                                                                                               short numberOfScreensBigRooms,
                                                                                               short numberOfScreensSmallRooms,
                                                                                               bool basedOnSuccessfullyFilmInCity)
        {
            var movieSourceHanlder = _movieSourceForIntelligentBillboardService.FirstOrDefault(x => x.isBasedOnSuccessfullyFilmInCity == basedOnSuccessfullyFilmInCity);
            var numberOfRoomsBySize = await _roomRepository.GetRoomsByNumberOfScreensAsync(numberOfScreensBigRooms, numberOfScreensSmallRooms);
            short currentState = 1; 
            var movies = await movieSourceHanlder.GetMostSuccessfullMoviesAsync(currentState);
            var alreadyTakenMovies = new HashSet<int>();
            var resultList = new List<BillboardSuggestionDTO>();
            var weeks = (int)(endDateTime - startDateTime).TotalDays / 7;

            for (var weekNumber = 1; weekNumber <= weeks; weekNumber++)
            {
                var weekSchedule = new BillboardSuggestionDTO();
                weekSchedule.WeekNumber = weekNumber;
                weekSchedule.CinemaRooms = new List<CinemaRoomsDTO>();

                foreach(var room in numberOfRoomsBySize.OrderBy(x => x.Size))
                {
                    var cinemaRoom = new CinemaRoomsDTO();
                    cinemaRoom.CinemaId = room.CinemaId;
                    cinemaRoom.RoomSize = room.Size;
                    cinemaRoom.RoomsMovies = new List<string>();

                    for (short screen = 1; screen <= room.NumberOfScreens; screen++)
                    {
                        var movie = movies.Where(x => !alreadyTakenMovies.Contains(x.Id))?.FirstOrDefault();
                        if(movie is null)
                        {
                            if(basedOnSuccessfullyFilmInCity) 
                            {
                                break;
                            }

                            currentState++;
                            movies = await movieSourceHanlder.GetMostSuccessfullMoviesAsync(currentState);
                            movie = movies.FirstOrDefault();
                        }

                        alreadyTakenMovies.Add(movie.Id);
                        cinemaRoom.RoomsMovies.Add(movie.Title);
                    }

                    if(cinemaRoom is not null && 
                       cinemaRoom.RoomsMovies.Any())
                    {
                        weekSchedule.CinemaRooms.Add(cinemaRoom);
                    }
                }

                if(weekSchedule is not null && 
                   weekSchedule.CinemaRooms.Any())
                {
                    resultList.Add(weekSchedule);
                }
            }

            return resultList;
        }

        public Task<List<MovieDTO>> GetRecommendedUpcomingMoviesByRateAndGenreAsync(DateTime startDate, decimal rate, string genre, bool basedOnSuccessfullyFilmInCity)
        {
            throw new NotImplementedException();
        }
    }
}