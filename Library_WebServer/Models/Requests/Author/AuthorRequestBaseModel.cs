using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Requests.Author;

public class AuthorRequestBaseModel
{
    [JsonPropertyName("FirstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("LastName")]
    public string LastName { get; set; } = string.Empty;

    public AuthorRequestBaseModel() { }

    public AuthorRequestBaseModel(
        string firstName, 
        string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
