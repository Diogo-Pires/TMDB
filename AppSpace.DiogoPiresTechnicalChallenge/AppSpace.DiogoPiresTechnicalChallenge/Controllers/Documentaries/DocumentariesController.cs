using AppSpace.API.Dtos;
using AppSpace.Application.Documentaries.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppSpace.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DocumentariesController : ControllerBase
    {
        private readonly IDocumentaryService _documentaryService;

        public DocumentariesController(IDocumentaryService documentaryService)
        {
            _documentaryService = documentaryService;
        }

        [HttpGet("GetAllRecommendedDocumentariesBasedOnTopics")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(List<DocumentaryDTO>))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<DocumentaryDTO>>> GetAllRecommendedDocumentariesBasedOnTopics([FromQuery] string[] topics)
        {
            try
            {
                var listOfDocumentaryRecomendations = await _documentaryService.GetAllRecommendedDocumentariesBasedOnTopicsAsync(topics: topics);
                if (listOfDocumentaryRecomendations is null ||
                    listOfDocumentaryRecomendations.Count == 0)
                {
                    return NoContent();
                }

                return Ok(listOfDocumentaryRecomendations);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessagesConstants.GENERAL_ERROR);
            }
        }
    }
}