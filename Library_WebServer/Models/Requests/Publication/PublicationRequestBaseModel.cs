using Library_WebServer.Enums;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Requests.Publication;

public class PublicationRequestBaseModel
{
    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("AuthorId")]
    public Guid AuthorId { get; set; }

    [JsonPropertyName("Type")]
    public LibraryObjectTypeEnum Type { get; set; }

    [JsonPropertyName("Genre")]
    public LibraryObjectGenreEnum Genre { get; set; }

    [JsonPropertyName("Status")]
    public LibraryObjectStatusEnum Status { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public PublicationRequestBaseModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    public PublicationRequestBaseModel(
        string name,
        Guid authorId,
        LibraryObjectTypeEnum objectType,
        LibraryObjectGenreEnum genre,
        LibraryObjectStatusEnum status)
    {
        Name = name;
        AuthorId = authorId;
        Type = objectType;
        Genre = genre;
        Status = status;
    }
}