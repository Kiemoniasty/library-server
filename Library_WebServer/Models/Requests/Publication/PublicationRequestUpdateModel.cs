using Library_WebServer.Enums;
using Library_WebServer.Models.Responses;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Requests.Publication;

public class PublicationRequestUpdateModel : PublicationRequestBaseModel
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public PublicationRequestUpdateModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public PublicationRequestUpdateModel(
        Guid id,
        string name,
        Guid authorId,
        LibraryObjectTypeEnum objectType,
        LibraryObjectGenreEnum genre,
        LibraryObjectStatusEnum status)
            : base(name, authorId, objectType, genre,status)
    {
        Id = id;
    }
}