using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Author.Request;

public class AuthorRequestUpdateModel : AuthorRequestBaseModel
{
    [JsonPropertyName("Id")]
    public string Id { get; set; }

    public AuthorRequestUpdateModel() { }

    public AuthorRequestUpdateModel(
        string id,
        string firstName,
        string lastName)
            : base(firstName, lastName)
    {
        Id = id;
    }
}
