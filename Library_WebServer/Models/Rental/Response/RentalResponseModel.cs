using Library_WebServer.Models.Rental.Database;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Rental.Response
{
    public class RentalResponseModel
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }

        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("IsBorrowed")]
        public bool IsBorrowed { get; set; }

        [JsonPropertyName("PublicationId")]
        public Guid PublicationId { get; set; }

        [JsonPropertyName("UserId")]
        public Guid UserId { get; set; }

        public RentalResponseModel() { }

        public RentalResponseModel(RentalDbModel rental)
        {
            Id = rental.Id;
            Date = rental.Date;
            IsBorrowed = rental.IsBorrowed;
            PublicationId = rental.LibraryPublication.Id;
            UserId = rental.LibraryUser.Id;
        }

        public RentalResponseModel(Guid id, DateTime date, bool isBorrowed, Guid publicationId, Guid userId)
        {
            Id = id;
            Date = date;
            IsBorrowed = isBorrowed;
            PublicationId = publicationId;
            UserId = userId;
        }
    }
}
