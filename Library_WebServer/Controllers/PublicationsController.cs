using Library_WebServer.Database;
using Library_WebServer.Models;
using Library_WebServer.Models.Author.Database;
using Library_WebServer.Models.Publication.Database;
using Library_WebServer.Models.Publication.Request;
using Library_WebServer.Models.Publication.Response;
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicationResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetPublication(Guid publicationId)
    {
        //TODO: Add request validation
        PublicationDbModel? publication = _libraryDbContext.Publications
            .Include(p => p.LibraryObjectType)
            .Include(p => p.LibraryObjectGenre)
            .Include(p => p.LibraryObjectStatus)
            .Include(p => p.LibraryAuthor)
            .Include(p => p.LibraryReservations)
                .ThenInclude(x => x.LibraryUser)
            .Include(p => p.LibraryComments)
                .ThenInclude(x => x.LibraryUser)
            .SingleOrDefault(x => x.Id == publicationId);

        if (publication == null)
        {
            return NotFound();
        }

        return Ok(new PublicationResponseModel(publication));
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicationResponseBaseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostPublication([FromBody] PublicationRequestBaseModel publication)
    {
        //TODO: Add request validation
        AuthorDbModel? author = _libraryDbContext.Authors
            .SingleOrDefault(x => x.Id == publication.AuthorId);

        if (author == null)
        {
            return BadRequest();
        }

        PublicationDbModel newPublication = new PublicationDbModel()
        {
            Name = publication.Name,
            Description = publication.Description,
            ReleaseYear = publication.ReleaseYear,
            LibraryAuthor = author,
            LibraryObjectType = _libraryDbContext.PublicationTypes.Single(x => x.Id == publication.Type),
            LibraryObjectGenre = _libraryDbContext.Genres.Single(x => x.Id == publication.Genre),
            LibraryObjectStatus = _libraryDbContext.Statuses.Single(x => x.Id == publication.Status),
            LibraryComments = new(),
            LibraryReservations = new()
        };

        _libraryDbContext.Publications.Add(newPublication);

        _libraryDbContext.SaveChanges();

        return Ok(new PublicationResponseBaseModel(newPublication));
    }

    [HttpPut]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicationResponseBaseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PutPublication([FromBody] PublicationRequestUpdateModel publication)
    {
        //TODO: Add request validation
        PublicationDbModel? newPublication = _libraryDbContext.Publications
            .Include(x => x.LibraryObjectType)
            .Include(x => x.LibraryObjectGenre)
            .Include(x => x.LibraryObjectStatus)
            .Include(x => x.LibraryAuthor)
            .Include(x => x.LibraryReservations)
            .Include(x => x.LibraryComments)
            .SingleOrDefault(p => p.Id == publication.Id);

        if (newPublication == null)
        {
            return BadRequest();
        }

        //TODO: Add db data validation
        newPublication.Name = publication.Name;
        newPublication.Description = publication.Description;
        newPublication.ReleaseYear = publication.ReleaseYear;
        newPublication.LibraryObjectType = _libraryDbContext.PublicationTypes.Single(x => x.Id == publication.Type);
        newPublication.LibraryObjectGenre = _libraryDbContext.Genres.Single(x => x.Id == publication.Genre);
        newPublication.LibraryObjectStatus = _libraryDbContext.Statuses.Single(x => x.Id == publication.Status);
        newPublication.LibraryAuthor = _libraryDbContext.Authors.Single(x => x.Id == publication.AuthorId);

        _libraryDbContext.Publications.Update(newPublication);

        _libraryDbContext.SaveChanges();

        return Ok(new PublicationResponseBaseModel(newPublication));
    }

    [HttpDelete]
    [Route("{publicationId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicationResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult DeletePublication(Guid publicationId)
    {
        //TODO: Add request validation
        PublicationDbModel? publication = _libraryDbContext.Publications
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseModel<PublicationResponseModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetPublications([FromQuery] int? top, [FromQuery] int? skip)
    {
        //TODO: Add request validation
        List<PublicationResponseModel> publications = _libraryDbContext.Publications
            .Include(x => x.LibraryObjectType)
            .Include(x => x.LibraryObjectGenre)
            .Include(x => x.LibraryObjectStatus)
            .Include(x => x.LibraryAuthor)
            .Include(x => x.LibraryReservations)
                .ThenInclude(x => x.LibraryUser)
            .Include(x => x.LibraryComments)
                .ThenInclude(x => x.LibraryUser)
            .OrderBy(x => x.Name)
            .Take(top ?? 10)
            .Skip(skip ?? 0)
            .Select(x => new PublicationResponseModel(x))
            .ToList();

        int count = _libraryDbContext.Publications.Count();

        return Ok(new PaginationResponseModel<PublicationResponseModel>(publications, count));
    }
}
