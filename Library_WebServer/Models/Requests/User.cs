using Library_WebServer.Enums;
using Library_WebServer.Models.Database;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Requests;
public class User
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }

    [JsonPropertyName("AccountType")]
    public UserAccountTypeEnum AccountType { get; set; }

    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("Password")]
    public string Password { get; set; } = string.Empty;

    [JsonPropertyName("Email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("PhoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;

    [JsonPropertyName("Address")]
    public string Address { get; set; } = string.Empty;

    public User() { }

    public User(LibraryUser user)
    {
        Id = user.Id;
        Name = user.Name;
        Password = user.Password;
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
        Address = user.Address;
        AccountType = user.UserAccountType.Id;
    }

    public User(Guid id, UserAccountTypeEnum accountType, string name, string password, string email, string phoneNumber, string address)
    {
        Id = id;
        AccountType = accountType;
        Name = name;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
    }
}
