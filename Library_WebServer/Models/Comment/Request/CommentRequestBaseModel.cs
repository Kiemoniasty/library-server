using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Comment.Request;

public class CommentRequestBaseModel
{
    [JsonPropertyName("Grade")]
    public ushort Grade { get; set; }

    [JsonPropertyName("Contents")]
    public string Contents { get; set; } = string.Empty;

    [JsonPropertyName("PublicationId")]
    public Guid PublicationId { get; set; }

    [JsonPropertyName("UserId")]
    public Guid UserId { get; set; }

    public CommentRequestBaseModel() { }


    public CommentRequestBaseModel(
        ushort grade,
        string contents,
        Guid publicationId,
        Guid userId)
    {
        Grade = grade;
        Contents = contents;
        PublicationId = publicationId;
        UserId = userId;
    }
}
