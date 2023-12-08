using AppSpace.API;
using AppSpace.API.Dtos;
using AppSpace.Application.Cinema.Interfaces;
using AppSpace.Application.Genres.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppSpaceDiogoPiresTechincalChallenge.Controllers.Movie
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService theaterManagerService)
        {
            _cinemaService = theaterManagerService;
        }

        [HttpGet("GetRecommendedUpcomingMoviesByRateAndGenre")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(List<MovieDTO>))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<MovieDTO>>> GetRecommendedUpcomingMoviesByRateAndGenre(
            [FromQuery] DateTime startDate, 
            [FromQuery] decimal rate, 
            [FromQuery] string genre,
            [FromQuery] bool basedOnSuccessfullyFilmInCity,
            [FromServices] IGenreService genreService)
        {
            try
            {
                if (!await genreService.IsGenresValidAsync(new string[] { genre }))
                {
                    return BadRequest($"Valid genres are: {(string.Join(',', await genreService.GetAllAsync()))}.");
                }

                var listOfMoviesRecomendations = await _cinemaService.GetRecommendedUpcomingMoviesByRateAndGenreAsync(
                    startDate: startDate,
                    rate: rate,
                    genre: genre,
                    basedOnSuccessfullyFilmInCity: basedOnSuccessfullyFilmInCity);

                if (listOfMoviesRecomendations is null ||
                    listOfMoviesRecomendations.Count == 0)
                {
                    return NoContent();
                }

                return Ok(listOfMoviesRecomendations);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessagesConstants.GENERAL_ERROR);
            }
        }

        [HttpGet("GetBillboardSuggestion")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(List<BillboardSuggestionDTO>))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BillboardSuggestionDTO>> GetBillboardSuggestion(
            [FromQuery] DateTime period,
            [FromQuery] short numberOfScreens,
            [FromQuery] bool basedOnSuccessfullyFilmInCity)
        {
            try
            {
                var suggestedBillboard = await _cinemaService.GetBillboardSuggestionAsync(
                    period: period,
                    numberOfScreens: numberOfScreens,
                    basedOnSuccessfullyFilmInCity: basedOnSuccessfullyFilmInCity);

                if (suggestedBillboard is null)
                {
                    return NoContent();
                }

                return Ok(suggestedBillboard);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessagesConstants.GENERAL_ERROR);
            }
        }

        [HttpGet("GetIntelligentBillboardSuggestion")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(List<BillboardSuggestionDTO>))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BillboardSuggestionDTO>>> GetIntelligentBillboardSuggestion(
            [FromQuery] DateTime startDateTime,
            [FromQuery] DateTime endDateTime,
            [FromQuery] short numberOfScreensBigRooms,
            [FromQuery] short numberOfScreensSmallRooms,
            [FromQuery] bool basedOnSuccessfullyFilmInCity)
        {
            try
            {
                var suggestedBillboardList = await _cinemaService.GetIntelligentBillboardSuggestionAsync(
                    startDateTime: startDateTime,
                    endDateTime: endDateTime,
                    numberOfScreensBigRooms: numberOfScreensBigRooms,
                    numberOfScreensSmallRooms: numberOfScreensSmallRooms,
                    basedOnSuccessfullyFilmInCity: basedOnSuccessfullyFilmInCity);

                if (suggestedBillboardList is null)
                {
                    return NoContent();
                }

                return Ok(suggestedBillboardList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessagesConstants.GENERAL_ERROR);
            }
        }
    }
}