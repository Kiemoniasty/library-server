using Library_WebServer.Models.Database;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Responses
{
    public class RentalResponseModel
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }

        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("IsBorrow")]
        public bool IsBorrow { get; set; }

        [JsonPropertyName("PublicationId")]
        public Guid PublicationId { get; set; }

        [JsonPropertyName("UserId")]
        public Guid UserId { get; set; }

        public RentalResponseModel() { }

        public RentalResponseModel(RentalDbModel rental)
        {
            Id = rental.Id;
            Date = rental.Date;
            IsBorrow = rental.IsBorrow;
            PublicationId = rental.LibraryPublication.Id;
            UserId = rental.LibraryUser.Id;
        }

        public RentalResponseModel(Guid id, DateTime date, bool isBorrow, Guid publicationId, Guid userId)
        {
            Id = id;
            Date = date;
            IsBorrow = isBorrow;
            PublicationId = publicationId;
            UserId = userId;
        }
    }
}
