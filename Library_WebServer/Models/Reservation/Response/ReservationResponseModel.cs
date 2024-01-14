using Library_WebServer.Models.Reservation.Database;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Reservation.Response;

public class ReservationResponseModel
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }

    [JsonPropertyName("Date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("PublicationId")]
    public Guid PublicationId { get; set; }

    [JsonPropertyName("UserId")]
    public Guid UserId { get; set; }

    public ReservationResponseModel() { }

    public ReservationResponseModel(ReservationDbModel reservation)
    {
        Id = reservation.Id;
        Date = reservation.Date;
        PublicationId = reservation.LibraryPublication.Id;
        UserId = reservation.LibraryUser.Id;
    }

    public ReservationResponseModel(Guid id, DateTime date, Guid publicationId, Guid userId)
    {
        Id = id;
        Date = date;
        PublicationId = publicationId;
        UserId = userId;
    }
}
