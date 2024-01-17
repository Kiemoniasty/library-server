namespace Library_WebServer.Models.Author.Domain;

public abstract class AuthorBase
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public AuthorBase(
        string firstName,
        string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}