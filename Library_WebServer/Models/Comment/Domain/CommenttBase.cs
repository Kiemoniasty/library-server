using Library_WebServer.Models.Comment.Request;

namespace Library_WebServer.Models.Comment.Domain;

public class CommentBase
{
    public ushort Grade { get; set; }

    public string Contents { get; set; } = string.Empty;

    public Guid PublicationId { get; set; }

    public Guid UserId { get; set; }

    public CommentBase(CommentRequestBaseModel model)
        : this(model.Grade, model.Contents, model.PublicationId, model.UserId) { }

    public CommentBase(
        string grade,
        string contents,
        string publicationId,
        string userId)
    {
        Grade = ushort.Parse(grade);
        Contents = contents;
        PublicationId = Guid.Parse(publicationId);
        UserId = Guid.Parse(userId);
    }
}
