using Library_WebServer.Interfaces;

namespace Library_WebServer.Models;

public class User : ILibraryObject
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public User() { }
    public User(Guid id, string name, string Email, string Address)
    {
        Id = id;
        Name = name;
        this.Email = Email;
        this.Address = Address;
    }
}
