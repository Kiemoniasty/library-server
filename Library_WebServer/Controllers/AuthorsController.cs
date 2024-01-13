using Library_WebServer.Database;
using Library_WebServer.Models.Database;
using Library_WebServer.Models.Requests.Author;
using Library_WebServer.Models.Responses;
using Microsoft.AspNetCore.Mvc;


namespace Library_WebServer.Controllers;

[ApiController]
[Route("[controller]/")]
public class AuthorsController : ControllerBase
{
    private readonly ILogger<AuthorsController> _logger;
    private readonly LibraryDbContext _libraryDbContext;

    public AuthorsController(ILogger<AuthorsController> logger, LibraryDbContext libraryDbContext)
    {
        _logger = logger;
        _libraryDbContext = libraryDbContext;
    }

    [HttpGet]
    [Route("{authorId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAuthor(Guid authorId)
    {
        //TODO: Add request validation
        AuthorDbModel? author = _libraryDbContext.Authors
            .SingleOrDefault(x => x.Id == authorId);

        if (author == null)
        {
            return NotFound();
        }

        return Ok(new AuthorResponseModel(author));
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostAuthor([FromBody] AuthorRequestBaseModel author)
    {
        //TODO: Add request validation
        AuthorDbModel newAuthor = new AuthorDbModel()
        {
            FirstName = author.FirstName,
            LastName = author.LastName
        };

        _libraryDbContext.Authors.Add(newAuthor);

        _libraryDbContext.SaveChanges();

        return Ok(new AuthorResponseModel(newAuthor));
    }

    [HttpPut]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PutAuthor([FromBody] AuthorRequestUpdateModel author)
    {
        //TODO: Add request validation
        AuthorDbModel? newAuthor = _libraryDbContext.Authors
            .SingleOrDefault(p => p.Id == author.Id);

        if (newAuthor == null)
        {
            return BadRequest();
        }

        newAuthor.FirstName = author.FirstName;
        newAuthor.LastName = author.LastName;

        _libraryDbContext.Authors.Update(newAuthor);

        _libraryDbContext.SaveChanges();

        return Ok(new AuthorResponseModel(newAuthor));
    }

    [HttpDelete]
    [Route("{authorId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult DeleteAuthor(Guid authorId)
    {
        //TODO: Add request validation
        AuthorDbModel? author = _libraryDbContext.Authors
            .SingleOrDefault(x => x.Id == authorId);

        if (author == null)
        {
            return NotFound();
        }

        _libraryDbContext.Authors.Remove(author);
        _libraryDbContext.SaveChanges();

        return Ok();
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseModel<AuthorResponseModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAuthors([FromQuery] int? top, [FromQuery] int? skip)
    {
        //TODO: Add request validation
        List<AuthorResponseModel> authors = _libraryDbContext.Authors
            .OrderBy(x => x.LastName)
            .Take(top ?? 10)
            .Skip(skip ?? 0)
            .Select(x => new AuthorResponseModel(x))
            .ToList();

        int count = _libraryDbContext.Authors.Count();

        return Ok(new PaginationResponseModel<AuthorResponseModel> (authors, count));
    }
}
