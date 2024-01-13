using Library_WebServer.Models.Database;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Responses;

public class ReservationResponseMode
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }

    [JsonPropertyName("Date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("PublicationId")]
    public Guid PublicationId { get; set; }

    [JsonPropertyName("UserId")]
    public Guid UserId { get; set; }

    public ReservationResponseMode() { }

    public ReservationResponseMode(ReservationDbModel reservation)
    {
        Id = reservation.Id;
        Date = reservation.Date;
        PublicationId = reservation.LibraryPublication.Id;
        UserId = reservation.LibraryUser.Id;
    }

    public ReservationResponseMode(Guid id, DateTime date, Guid publicationId, Guid userId)
    {
        Id = id;
        Date = date;
        PublicationId = publicationId;
        UserId = userId;
    }
}
