using Library_WebServer.Database;
using Library_WebServer.Models.Database;
using Library_WebServer.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Library_WebServer.Controllers;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Publication))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetPublication(Guid publicationId)
    {
        //TODO: Add request validation
        LibraryPublication? publication = _libraryDbContext.Publications
            .Include(p => p.LibraryObjectType)
            .Include(p => p.LibraryObjectGenre)
            .Include(p => p.LibraryObjectStatus)
            .Include(p => p.LibraryAuthor)
            .Include(p => p.LibraryReservations)
            .SingleOrDefault(x => x.Id == publicationId);

        if (publication == null)
        {
            return NotFound();
        }

        return Ok(new Publication(publication));
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Publication))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostPublication([FromBody] Publication publication)
    {
        //TODO: Add request validation
        LibraryAuthor? author = _libraryDbContext.Authors
            .SingleOrDefault(x => x.Id == publication.Author.Id);

        if (author == null)
        {
            return BadRequest();
        }

        LibraryPublication newPublication = new LibraryPublication()
        {
            Name = publication.Name,
            LibraryAuthor = author,
            LibraryObjectType = _libraryDbContext.PublicationTypes.Single(x => x.Id == publication.Type),
            LibraryObjectGenre = _libraryDbContext.Genres.Single(x => x.Id == publication.Genre),
            LibraryObjectStatus = _libraryDbContext.Statuses.Single(x => x.Id == publication.Status),
            LibraryReservations = new()
        };

        _libraryDbContext.Publications.Add(newPublication);

        _libraryDbContext.SaveChanges();

        return Ok(new Publication(newPublication));
    }

    [HttpPut]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Publication))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PutPublication([FromBody] Publication publication)
    {
        //TODO: Add request validation
        LibraryPublication? newPublication = _libraryDbContext.Publications
            .Include(p => p.LibraryObjectType)
            .Include(p => p.LibraryObjectGenre)
            .Include(p => p.LibraryObjectStatus)
            .Include(p => p.LibraryAuthor)
            .Include(p => p.LibraryReservations)
            .SingleOrDefault(p => p.Id == publication.Id);

        if (newPublication == null)
        {
            return BadRequest();
        }

        //TODO: Add db data validation
        newPublication.Name = publication.Name;
        newPublication.LibraryObjectType = _libraryDbContext.PublicationTypes.Single(x => x.Id == publication.Type);
        newPublication.LibraryObjectGenre = _libraryDbContext.Genres.Single(x => x.Id == publication.Genre);
        newPublication.LibraryObjectStatus = _libraryDbContext.Statuses.Single(x => x.Id == publication.Status);
        newPublication.LibraryAuthor = _libraryDbContext.Authors.Single(x => x.Id == publication.Author.Id);

        _libraryDbContext.Publications.Update(newPublication);

        _libraryDbContext.SaveChanges();

        return Ok(new Publication(newPublication));
    }

    [HttpDelete]
    [Route("{publicationId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Publication))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult DeletePublication(Guid publicationId)
    {
        //TODO: Add request validation
        LibraryPublication? publication = _libraryDbContext.Publications
            .SingleOrDefault(x => x.Id == publicationId);

        if (publication == null)
        {
            return NotFound();
        }

        _libraryDbContext.Publications.Remove(publication);
        _libraryDbContext.SaveChanges();

        return Ok();
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Publication))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetPublications([FromQuery] int? top, [FromQuery] int? skip)
    {
        //TODO: Add request validation
        List<Publication> publications = _libraryDbContext.Publications
            .Include(p => p.LibraryObjectType)
            .Include(p => p.LibraryObjectGenre)
            .Include(p => p.LibraryObjectStatus)
            .Include(p => p.LibraryAuthor)
            .Include(p => p.LibraryReservations)
            .OrderBy(x => x.Name)
            .Take(top ?? 10)
            .Skip(skip ?? 0)
            .Select(x => new Publication(x))
            .ToList();

        return Ok(publications);
    }
}
