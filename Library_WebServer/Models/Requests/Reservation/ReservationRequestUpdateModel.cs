using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Requests.Reservation;

public class ReservationRequestUpdateModel : ReservationRequestBaseModel
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }

    public ReservationRequestUpdateModel() { }

    public ReservationRequestUpdateModel(
        Guid id,
        DateTime date,
        Guid publicationId,
        Guid userId) : base(date, publicationId, userId)
    {
        Id = id;
    }
}
