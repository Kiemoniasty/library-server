using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Comment.Request;

public class CommentRequestBaseModel
{
    [JsonPropertyName("Grade")]
    public string Grade { get; set; }

    [JsonPropertyName("Contents")]
    public string Contents { get; set; } = string.Empty;

    [JsonPropertyName("PublicationId")]
    public string PublicationId { get; set; }

    [JsonPropertyName("UserId")]
    public string UserId { get; set; }

    public CommentRequestBaseModel() { }

    public CommentRequestBaseModel(
        string grade,
        string contents,
        string publicationId,
        string userId)
    {
        Grade = grade;
        Contents = contents;
        PublicationId = publicationId;
        UserId = userId;
    }
}
