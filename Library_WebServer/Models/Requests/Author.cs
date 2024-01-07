using Library_WebServer.Models.Database;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Requests;

public class Author
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }

    [JsonPropertyName("FirstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("LastName")]
    public string LastName { get; set; } = string.Empty;

    public Author () { }

    public Author(LibraryAuthor author)
    {
        Id = author.Id;
        FirstName = author.FirstName;
        LastName = author.LastName;
    }

    public Author(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}
