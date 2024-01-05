using Library_WebServer.Database;
using Library_WebServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Library_WebServer.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;
        private readonly LibraryDbContext _libraryDbContext;

        public CommentsController(ILogger<CommentsController> logger, LibraryDbContext libraryDbContext)
        {
            _logger = logger;
            _libraryDbContext = libraryDbContext;
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
            LibraryComment newComment = new LibraryComment()
            {
                Grade = comment.Grade,
                Contents = comment.Contents,
                PublicationId = _libraryDbContext.Publications.Single(x => x.Id == comment.PublicationId).Id,
                UserId = _libraryDbContext.Users.Single(x => x.Id == comment.UserId).Id
            };

            _libraryDbContext.Comments.Add(newComment);

            _libraryDbContext.SaveChanges();

            return Ok(newComment);
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PutComment([FromBody] LibraryComment comment)
        {
            LibraryComment newComment = new LibraryComment()
            {
                Id = comment.Id,
                Grade = comment.Grade,
                Contents = comment.Contents,
                PublicationId = _libraryDbContext.Publications.Single(x => x.Id == comment.PublicationId).Id,
                UserId = _libraryDbContext.Users.Single(x => x.Id == comment.UserId).Id
            };

            _libraryDbContext.Comments.Update(newComment);

            _libraryDbContext.SaveChanges();

            return Ok(newComment);
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
