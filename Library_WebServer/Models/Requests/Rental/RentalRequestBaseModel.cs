using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Requests.Rental
{
    public class RentalRequestBaseModel
    {
        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("IsBorrow")]
        public bool IsBorrow { get; set; }

        [JsonPropertyName("PublicationId")]
        public Guid PublicationId { get; set; }

        [JsonPropertyName("UserId")]
        public Guid UserId { get; set; }

        public RentalRequestBaseModel() { }

        public RentalRequestBaseModel(
            DateTime date,
            bool isBorrow,
            Guid publicationId,
            Guid userId)
        {
            Date = date;
            IsBorrow = isBorrow;
            PublicationId = publicationId;
            UserId = userId;
        }
    }
}
