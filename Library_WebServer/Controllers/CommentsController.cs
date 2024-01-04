using Library_WebServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebServer.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(ILogger<CommentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{commentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetComment([FromRoute] Guid commentId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostComment([FromBody] LibraryComment comment)
        {
            return Ok();
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PutComment([FromBody] LibraryComment comment)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{publicationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteComment([FromRoute] Guid commentId)
        {
            return Ok();
        }
    }
}
