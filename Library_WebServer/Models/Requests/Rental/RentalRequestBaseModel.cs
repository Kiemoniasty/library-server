using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Requests.Rental
{
    public class RentalRequestBaseModel
    {
        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("IsBorrowed")]
        public bool IsBorrowed { get; set; }

        [JsonPropertyName("PublicationId")]
        public Guid PublicationId { get; set; }

        [JsonPropertyName("UserId")]
        public Guid UserId { get; set; }

        public RentalRequestBaseModel() { }

        public RentalRequestBaseModel(
            DateTime date,
            bool isBorrowed,
            Guid publicationId,
            Guid userId)
        {
            Date = date;
            IsBorrowed = isBorrowed;
            PublicationId = publicationId;
            UserId = userId;
        }
    }
}
