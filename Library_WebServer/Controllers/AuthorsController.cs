using Library_WebServer.Database;
using Library_WebServer.Models;
using Library_WebServer.Models.Author.Database;
using Library_WebServer.Models.Author.Domain;
using Library_WebServer.Models.Author.Request;
using Library_WebServer.Models.Author.Response;
using Library_WebServer.Validators;
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
    public IActionResult GetAuthor(string authorId)
    {
        if (!authorId.IsValidGuid(out string message))
        {
            return BadRequest(message);
        }

        Guid authorGuid = Guid.Parse(authorId);

        AuthorDbModel? author = _libraryDbContext.Authors
            .SingleOrDefault(x => x.Id == authorGuid);

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
    public IActionResult PostAuthor([FromBody] AuthorRequestBaseModel authorRequest)
    {
        if (!authorRequest.IsValid(out string message))
        {
            return BadRequest(message);
        }

        AuthorDbModel newAuthor = new AuthorDbModel()
        {
            FirstName = authorRequest.FirstName,
            LastName = authorRequest.LastName
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
    public IActionResult PutAuthor([FromBody] AuthorRequestUpdateModel authorRequest)
    {
        if (!authorRequest.IsValid(out string message))
        {
            return BadRequest(message);
        }

        var author = new Author(authorRequest);

        AuthorDbModel? newAuthor = _libraryDbContext.Authors
            .SingleOrDefault(p => p.Id == author.Id);

        if (newAuthor == null)
        {
            return BadRequest();
        }

        newAuthor.FirstName = authorRequest.FirstName;
        newAuthor.LastName = authorRequest.LastName;

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
    public IActionResult DeleteAuthor(string authorId)
    {
        if (!authorId.IsValidGuid(out string message))
        {
            return BadRequest(message);
        }

        Guid authorGuid = Guid.Parse(authorId);

        AuthorDbModel? author = _libraryDbContext.Authors
            .SingleOrDefault(x => x.Id == authorGuid);

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
    public IActionResult GetAuthors([FromQuery] string? top, [FromQuery] string? skip)
    {
        int topInt = 10, skipInt = 0;
        
        if (top != null)
        {
            if (!top.IsValidTop(out string message))
            {
                return BadRequest(message);
            }

            topInt = int.Parse(top);
        }


        if (skip != null)
        {
            if (!skip.IsValidSkip(out string message))
            {
                return BadRequest(message);
            }

            skipInt = int.Parse(skip);
        }

        List<AuthorResponseModel> authors = _libraryDbContext.Authors
            .OrderBy(x => x.LastName)
            .Skip(skipInt)
            .Take(topInt)
            .Select(x => new AuthorResponseModel(x))
            .ToList();

        int count = _libraryDbContext.Authors.Count();

        return Ok(new PaginationResponseModel<AuthorResponseModel>(authors, count));
    }
}
