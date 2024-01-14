using Library_WebServer.Database;
using Library_WebServer.Models;
using Library_WebServer.Models.Comment.Database;
using Library_WebServer.Models.Comment.Request;
using Library_WebServer.Models.Comment.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_WebServer.Controllers;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetComment(Guid commentId)
    {
        //TODO: Add request validation
        CommentDbModel? comment = _libraryDbContext.Comments
            .Include(x=>x.LibraryPublication)
            .Include(x => x.LibraryUser)
            .SingleOrDefault(x => x.Id == commentId);

        if (comment == null)
        {
            return NotFound();
        }

        return Ok(new CommentResponseModel(comment));
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostComment([FromBody] CommentRequestBaseModel comment)
    {
        //TODO: Add request validation
        //TODO: Add db data validation
        CommentDbModel newComment = new CommentDbModel()
        {
            Grade = comment.Grade,
            Contents = comment.Contents,
            LibraryPublication = _libraryDbContext.Publications.Single(x => x.Id == comment.PublicationId),
            LibraryUser = _libraryDbContext.Users.Single(x => x.Id == comment.UserId)
        };

        _libraryDbContext.Comments.Add(newComment);

        _libraryDbContext.SaveChanges();

        return Ok(new CommentResponseModel(newComment));
    }

    [HttpPut]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PutComment([FromBody] CommentRequestUpdateModel comment)
    {
        //TODO: Add request validation
        CommentDbModel? newComment = _libraryDbContext.Comments
            .SingleOrDefault(p => p.Id == comment.Id);

        if (newComment == null)
        {
            return BadRequest();
        }

        //TODO: Add db data validation
        newComment.Id = comment.Id;
        newComment.Grade = comment.Grade;
        newComment.Contents = comment.Contents;
        newComment.LibraryPublication = _libraryDbContext.Publications.Single(x => x.Id == comment.PublicationId);
        newComment.LibraryUser = _libraryDbContext.Users.Single(x => x.Id == comment.UserId);

        _libraryDbContext.Comments.Update(newComment);

        _libraryDbContext.SaveChanges();

        return Ok(new CommentResponseModel(newComment));
    }

    [HttpDelete]
    [Route("{commentId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult DeleteComment(Guid commentId)
    {
        //TODO: Add request validation
        var comment = _libraryDbContext.Comments.SingleOrDefault(x => x.Id == commentId);

        if (comment == null)
        {
            return NotFound();
        }

        _libraryDbContext.Comments.Remove(comment);

        _libraryDbContext.SaveChanges();

        return Ok();
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseModel<CommentResponseModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetComments([FromQuery] int? top, [FromQuery] int? skip)
    {
        //TODO: Add date to comment (db/model)
        //TODO: Add request validation
        List<CommentResponseModel> comments = _libraryDbContext.Comments
            .Include(x => x.LibraryPublication)
            .Include(x => x.LibraryUser)
            .OrderBy(x => x.Grade)
            .Take(top ?? 10)
            .Skip(skip ?? 0)
            .Select(x => new CommentResponseModel(x))
            .ToList();

        int count = _libraryDbContext.Comments.Count();

        return Ok(new PaginationResponseModel<CommentResponseModel>(comments, count));
    }
}
