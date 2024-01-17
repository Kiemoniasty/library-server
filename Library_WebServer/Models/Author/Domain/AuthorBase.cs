using Library_WebServer.Models.Author.Request;

namespace Library_WebServer.Models.Author.Domain;

public class AuthorBase
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public AuthorBase(AuthorRequestBaseModel model)
        : this(model.FirstName, model.LastName) { }

    public AuthorBase(
        string firstName,
        string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}