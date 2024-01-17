using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Comment.Request;

public class CommentRequestUpdateModel : CommentRequestBaseModel
{
    [JsonPropertyName("Id")]
    public string Id { get; set; }

    public CommentRequestUpdateModel() { }

    public CommentRequestUpdateModel(
        string id,
        string grade,
        string contents,
        string publicationId,
        string userId)
            : base(grade, contents, publicationId, userId)
    {
        Id = id;
    }
}
