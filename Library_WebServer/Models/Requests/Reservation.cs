using Library_WebServer.Models.Database;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Requests;

public class Reservation
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }

    [JsonPropertyName("Date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("PublicationId")]
    public Guid PublicationId { get; set; }

    [JsonPropertyName("UserId")]
    public Guid UserId { get; set; }

    public Reservation() { }

    public Reservation(LibraryReservation reservation)
    {
        Id = reservation.Id;
        Date = reservation.Date;
        PublicationId = reservation.LibraryPublication.Id;
        UserId = reservation.LibraryUser.Id;
    }

    public Reservation(Guid id, DateTime date, Guid publicationId, Guid userId)
    {
        Id = id;
        Date = date;
        PublicationId = publicationId;
        UserId = userId;
    }
}
