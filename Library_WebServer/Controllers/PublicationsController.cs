using Library_WebServer.Database;
using Library_WebServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Xml.Linq;


namespace Library_WebServer.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class PublicationsController : ControllerBase
    {
        private readonly ILogger<PublicationsController> _logger;
        private readonly LibraryDbContext _libraryDbContext;

        public PublicationsController(ILogger<PublicationsController> logger, LibraryDbContext libraryDbContext)
        {
            _logger = logger;
            _libraryDbContext = libraryDbContext;
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
            LibraryPublication newPublication = new LibraryPublication()
            {
                Name = publication.Name,
                LibraryObjectType = _libraryDbContext.PublicationTypes.Single(x => x.Id == publication.LibraryObjectType.Id),
                LibraryObjectGenre = _libraryDbContext.Genres.Single(x => x.Id == publication.LibraryObjectGenre.Id),
            };

            _libraryDbContext.Publications.Add(newPublication);

            _libraryDbContext.SaveChanges();

            return Ok(newPublication);
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryPublication))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PutPublication([FromBody] LibraryPublication publication)
        {
            LibraryPublication newPublication = new LibraryPublication()
            {
                Id = publication.Id,
                Name = publication.Name,
                LibraryObjectType = _libraryDbContext.PublicationTypes.Single(x => x.Id == publication.LibraryObjectType.Id),
                LibraryObjectGenre = _libraryDbContext.Genres.Single(x => x.Id == publication.LibraryObjectGenre.Id),
            };

            _libraryDbContext.Publications.Update(newPublication);

            _libraryDbContext.SaveChanges();

            return Ok(newPublication);
        }

        [HttpDelete]
        [Route("{publicationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryPublication))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePublication( Guid publicationId)
        {
            var publication = _libraryDbContext.Publications.SingleOrDefault(x => x.Id == publicationId);

            if (publication == null)
            {
                return NotFound();
            }

            _libraryDbContext.Publications.Remove(publication);
            _libraryDbContext.SaveChanges();

            return Ok();
        }
    }
}
