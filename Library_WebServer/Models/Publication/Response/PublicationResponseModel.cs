using Library_WebServer.Models.Author.Response;
using Library_WebServer.Models.Comment.Response;
using Library_WebServer.Models.Enums;
using Library_WebServer.Models.Publication.Database;
using Library_WebServer.Models.Reservation.Response;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Publication.Response;

public class PublicationResponseModel : PublicationResponseBaseModel
{
    [JsonPropertyName("Reservations")]
    public List<ReservationResponseModel> Reservations { get; set; }

    [JsonPropertyName("Comments")]
    public List<CommentResponseModel> Comments { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public PublicationResponseModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public PublicationResponseModel(PublicationDbModel publication)
    {
        Id = publication.Id;
        Name = publication.Name;
        Description = publication.Description;
        ReleaseYear = publication.ReleaseYear;
        Author = new AuthorResponseModel(publication.LibraryAuthor);
        Type = publication.LibraryObjectType.Id;
        Genre = publication.LibraryObjectGenre.Id;
        Status = publication.LibraryObjectStatus.Id;
        Reservations = publication.LibraryReservations.Select(x => new ReservationResponseModel(x)).ToList();
        Comments = publication.LibraryComments.Select(x => new CommentResponseModel(x)).ToList();
    }

    public PublicationResponseModel(
        Guid id,
        string name,
        string description,
        DateTime releaseYear,
        AuthorResponseModel author,
        LibraryObjectTypeEnum objectType,
        LibraryObjectGenreEnum genre,
        LibraryObjectStatusEnum status,
        List<ReservationResponseModel> reservations,
        List<CommentResponseModel> comments) : base(id, name, description, releaseYear, author, objectType, genre, status)
    {
        Reservations = reservations;
        Comments = comments;
    }
}