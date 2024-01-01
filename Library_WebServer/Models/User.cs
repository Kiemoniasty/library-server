using Library_WebServer.Enums;

namespace Library_WebServer.Models;

public class User 
{
    public Guid Id { get; set; }
    public UserAccountType UserAccountTypeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Password {  get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public User() { }

    public User(Guid id, UserAccountType accountType, string name, string password, string email, string phoneNumber, string address)
    {
        Id = id;
        UserAccountTypeId = accountType;
        Name = name;
        Password = password;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
        this.Address = address;
    }
}
