using AppSpace.API;
using AppSpace.API.Dtos;
using AppSpace.Application.Genres.Interfaces;
using AppSpace.Application.TvShows.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppSpaceDiogoPiresTechincalChallenge.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TvShowController : ControllerBase
    {
        private readonly ITvShowService _tvShowService;
        private readonly IGenreService _genreService;

        public TvShowController(ITvShowService tvShowService,
                                IGenreService genreService)
        {
            _tvShowService = tvShowService;
            _genreService = genreService;
        }

        [HttpGet("GetAllTimeRecommendedTvShowsByTagsAndOrGenres")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(List<TvShowDTO>))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TvShowDTO>>> GetAllTimeRecommendedTvShowsByTagsAndOrGenres([FromQuery] string[] tags, [FromQuery] string[] genres)
        {
            try
            {
                if (!(await _genreService.IsGenresValidAsync(genres)))
                {
                    return BadRequest($"Valid genres are: {(string.Join(',', await _genreService.GetAllAsync()))}.");
                }

                var listOfTvShowRecomendations = await _tvShowService.GetAllTimeRecommendedTvShowsByTagsAndOrGenresAsync(
                    tags: tags,
                    genres: genres);

                if (listOfTvShowRecomendations is null ||
                    listOfTvShowRecomendations.Count == 0)
                {
                    return NoContent();
                }

                return Ok(listOfTvShowRecomendations);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessagesConstants.GENERAL_ERROR);
            }
        }
    }
}