using Library_WebServer.Models.Comment.Database;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Comment.Response;

public class CommentResponseModel
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }

    [JsonPropertyName("Grade")]
    public ushort Grade { get; set; }

    [JsonPropertyName("Contents")]
    public string Contents { get; set; } = string.Empty;

    [JsonPropertyName("PublicationId")]
    public Guid PublicationId { get; set; }

    [JsonPropertyName("UserId")]
    public Guid UserId { get; set; }

    public CommentResponseModel() { }

    public CommentResponseModel(CommentDbModel comment)
    {
        Id = comment.Id;
        Grade = comment.Grade;
        Contents = comment.Contents;
        PublicationId = comment.LibraryPublication.Id;
        UserId = comment.LibraryUser.Id;
    }

    public CommentResponseModel(Guid id, ushort grade, string contents, Guid publicationId, Guid userId)
    {
        Id = id;
        Grade = grade;
        Contents = contents;
        PublicationId = publicationId;
        UserId = userId;
    }
}
