using Library_WebServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebServer.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class PublicationsController : ControllerBase
    {
        private readonly ILogger<PublicationsController> _logger;

        public PublicationsController(ILogger<PublicationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{publicationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryPublication))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPublication([FromRoute] Guid publicationId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryPublication))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostPublication([FromBody] LibraryPublication publication)
        {
            return Ok();
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryPublication))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PutPublication([FromBody] LibraryPublication publication)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{publicationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryPublication))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePublication([FromRoute] Guid publicationId)
        {
            return Ok();
        }
    }
}
