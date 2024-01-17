using Library_WebServer.Models.Comment.Request;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Comment.Domain;

public class Comment : CommentBase
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }

    public Comment(
        string id,
        string grade,
        string contents,
        string publicationId,
        string userId)
            : base(grade, contents, publicationId, userId)
    {
        Id = Guid.Parse(id);
    }

    public Comment(CommentRequestUpdateModel model)
                : this(model.Id, model.Grade, model.Contents, model.PublicationId, model.UserId) { }
}
