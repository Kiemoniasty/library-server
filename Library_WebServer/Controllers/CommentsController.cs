using Library_WebServer.Database;
using Library_WebServer.Models;
using Library_WebServer.Models.Comment.Database;
using Library_WebServer.Models.Comment.Domain;
using Library_WebServer.Models.Comment.Request;
using Library_WebServer.Models.Comment.Response;
using Library_WebServer.Models.Publication.Database;
using Library_WebServer.Models.User.Database;
using Library_WebServer.Validators;
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
    public IActionResult GetComment(string commentId)
    {
        if (!commentId.IsValidGuid(out string message))
        {
            return BadRequest(message);
        }

        Guid commentGuid = Guid.Parse(commentId);

        CommentDbModel? comment = _libraryDbContext.Comments
            .Include(x => x.LibraryPublication)
            .Include(x => x.LibraryUser)
            .SingleOrDefault(x => x.Id == commentGuid);

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
    public IActionResult PostComment([FromBody] CommentRequestBaseModel commentRequest)
    {
        if (!commentRequest.IsValid(out string message))
        {
            return BadRequest(message);
        }

        CommentBase comment = new CommentBase(commentRequest);

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
    public IActionResult PutComment([FromBody] CommentRequestUpdateModel commentRequest)
    {
        if (!commentRequest.IsValid(out string message))
        {
            return BadRequest(message);
        }

        Comment comment = new Comment(commentRequest);

        CommentDbModel? newComment = _libraryDbContext.Comments
            .SingleOrDefault(p => p.Id == comment.Id);

        if (newComment == null)
        {
            return BadRequest();
        }

        PublicationDbModel? publication = _libraryDbContext.Publications
            .SingleOrDefault(x => x.Id == comment.PublicationId);
        
        if (publication == null) 
        {
            return BadRequest("Publication for assignment was not found");
        }

        UserDbModel? user = _libraryDbContext.Users
            .SingleOrDefault(x => x.Id == comment.UserId);

        if (user == null)
        {
            return BadRequest("User for assignment was not found");
        }

        newComment.Id = comment.Id;
        newComment.Grade = comment.Grade;
        newComment.Contents = comment.Contents;
        newComment.LibraryPublication = publication;
        newComment.LibraryUser = user;

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
    public IActionResult DeleteComment(string commentId)
    {
        if (!commentId.IsValidGuid(out string message))
        {
            return BadRequest(message);
        }

        Guid commentGuid = Guid.Parse(commentId);

        CommentDbModel? comment = _libraryDbContext.Comments.SingleOrDefault(x => x.Id == commentGuid);

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
    public IActionResult GetComments([FromQuery] string? top, [FromQuery] string? skip)
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

        List<CommentResponseModel> comments = _libraryDbContext.Comments
            .Include(x => x.LibraryPublication)
            .Include(x => x.LibraryUser)
            .OrderBy(x => x.Grade)
            .Take(topInt)
            .Skip(skipInt)
            .Select(x => new CommentResponseModel(x))
            .ToList();

        int count = _libraryDbContext.Comments.Count();

        return Ok(new PaginationResponseModel<CommentResponseModel>(comments, count));
    }
}
