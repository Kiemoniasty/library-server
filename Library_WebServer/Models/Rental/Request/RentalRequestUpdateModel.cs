using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Rental.Request
{
    public class RentalRequestUpdateModel : RentalRequestBaseModel
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }

        public RentalRequestUpdateModel() { }

        public RentalRequestUpdateModel(
            Guid id,
            DateTime date,
            bool isBorrowed,
            Guid publicationId,
            Guid userId) : base(date, isBorrowed, publicationId, userId)
        {
            Id = id;
        }
    }
}
