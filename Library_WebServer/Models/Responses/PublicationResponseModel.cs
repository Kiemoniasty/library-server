using Library_WebServer.Enums;
using Library_WebServer.Models.Database;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Responses;

public class PublicationResponseModel
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }

    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("Author")]
    public AuthorResponseModel Author { get; set; }

    [JsonPropertyName("Type")]
    public LibraryObjectTypeEnum Type { get; set; }

    [JsonPropertyName("Genre")]
    public LibraryObjectGenreEnum Genre { get; set; }

    [JsonPropertyName("Status")]
    public LibraryObjectStatusEnum Status { get; set; }

    [JsonPropertyName("Reservations")]
    public List<ReservationResponseModel> Reservations { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public PublicationResponseModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public PublicationResponseModel(PublicationDbModel publication)
    {
        Id = publication.Id;
        Name = publication.Name;
        Author = new AuthorResponseModel(publication.LibraryAuthor);
        Type = publication.LibraryObjectType.Id;
        Genre = publication.LibraryObjectGenre.Id;
        Status = publication.LibraryObjectStatus.Id;
        Reservations = publication.LibraryReservations.Select(x => new ReservationResponseModel(x)).ToList();
    }

    public PublicationResponseModel(
        Guid id,
        string name,
        AuthorResponseModel author,
        LibraryObjectTypeEnum objectType,
        LibraryObjectGenreEnum genre,
        LibraryObjectStatusEnum status,
        List<ReservationResponseModel> reservations)
    {
        Id = id;
        Name = name;
        Author = author;
        Type = objectType;
        Genre = genre;
        Status = status;
        Reservations = reservations;
    }
}