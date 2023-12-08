using AppSpace.API.Dtos;
using AppSpace.Application.Genres.Interfaces;
using AppSpace.Application.Movies.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppSpace.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        public MoviesController(IMovieService movieService,
                                IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        [HttpGet("GetAllTimeRecommendedMoviesByTagsAndOrGenres")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(List<MovieDTO>))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<MovieDTO>>> GetAllTimeRecommendedMoviesByTagsAndOrGenres([FromQuery] string[] tags, [FromQuery] string[] genres)
        {
            try
            {
                if (!(await _genreService.IsGenresValidAsync(genres)))
                {
                    return BadRequest($"Valid genres are: {(string.Join(',', await _genreService.GetAllAsync()))}.");
                }

                var listOfMoviesRecomendations = await _movieService.GetAllTimeRecommendedMoviesByTagsAndOrGenresAsync(
                    tags: tags,
                    genres: genres);

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

        [HttpGet("GetRecommendedUpcomingMoviesByTagsAndOrGenres")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(List<MovieDTO>))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<MovieDTO>>> GetRecommendedUpcomingMoviesByTagsAndOrGenres(
            [FromQuery] DateTime startDate,
            [FromQuery] string[] tags,
            [FromQuery] string[] genres)
        {
            try
            {
                if (!(await _genreService.IsGenresValidAsync(genres)))
                {
                    return BadRequest($"Valid genres are: {(string.Join(',', await _genreService.GetAllAsync()))}.");
                }

                var listOfMoviesRecomendations = await _movieService.GetRecommendedUpcomingMoviesByTagsAndOrGenresAsync(
                    startDate: startDate,
                    tags: tags,
                    genres: genres);

                if (listOfMoviesRecomendations is null ||
                    listOfMoviesRecomendations.Count == 0)
                {
                    return NoContent();
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessagesConstants.GENERAL_ERROR);
            }
        }
    }
}