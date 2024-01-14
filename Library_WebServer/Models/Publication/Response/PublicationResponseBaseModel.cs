using Library_WebServer.Enums;
using Library_WebServer.Models.Author.Response;
using Library_WebServer.Models.Publication.Database;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Publication.Response;

public class PublicationResponseBaseModel
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }

    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("Description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("ReleaseYear")]
    public DateTime ReleaseYear { get; set; }

    [JsonPropertyName("Author")]
    public AuthorResponseModel Author { get; set; }

    [JsonPropertyName("Type")]
    public LibraryObjectTypeEnum Type { get; set; }

    [JsonPropertyName("Genre")]
    public LibraryObjectGenreEnum Genre { get; set; }

    [JsonPropertyName("Status")]
    public LibraryObjectStatusEnum Status { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public PublicationResponseBaseModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public PublicationResponseBaseModel(PublicationDbModel publication)
    {
        Id = publication.Id;
        Name = publication.Name;
        Description = publication.Description;
        ReleaseYear = publication.ReleaseYear;
        Author = new AuthorResponseModel(publication.LibraryAuthor);
        Type = publication.LibraryObjectType.Id;
        Genre = publication.LibraryObjectGenre.Id;
        Status = publication.LibraryObjectStatus.Id;
    }

    public PublicationResponseBaseModel(
        Guid id,
        string name,
        string description,
        DateTime releaseYear,
        AuthorResponseModel author,
        LibraryObjectTypeEnum objectType,
        LibraryObjectGenreEnum genre,
        LibraryObjectStatusEnum status)
    {
        Id = id;
        Name = name;
        Description = description;
        ReleaseYear = releaseYear;
        Author = author;
        Type = objectType;
        Genre = genre;
        Status = status;
    }
}