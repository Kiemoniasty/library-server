using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Requests.Reservation;

public class ReservationRequestBaseModel
{
    [JsonPropertyName("Date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("PublicationId")]
    public Guid PublicationId { get; set; }

    [JsonPropertyName("UserId")]
    public Guid UserId { get; set; }

    public ReservationRequestBaseModel() { }

    public ReservationRequestBaseModel(
        DateTime date, 
        Guid publicationId, 
        Guid userId)
    {
        Date = date;
        PublicationId = publicationId;
        UserId = userId;
    }
}
