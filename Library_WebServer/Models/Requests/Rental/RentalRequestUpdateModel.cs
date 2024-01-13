using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Requests.Rental
{
    public class RentalRequestUpdateModel : RentalRequestBaseModel
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }

        public RentalRequestUpdateModel() { }

        public RentalRequestUpdateModel(
            Guid id,
            DateTime date,
            bool isBorrow,
            Guid publicationId,
            Guid userId) : base(date, isBorrow, publicationId, userId)
        {
            Id = id;
        }
    }
}
