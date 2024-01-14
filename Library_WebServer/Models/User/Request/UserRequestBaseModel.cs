using Library_WebServer.Enums;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.User.Request;
public class UserRequestBaseModel
{
    [JsonPropertyName("AccountType")]
    public UserAccountTypeEnum AccountType { get; set; }

    [JsonPropertyName("FirstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("FirstName")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("Password")]
    public string Password { get; set; } = string.Empty;

    [JsonPropertyName("Email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("PhoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;

    [JsonPropertyName("Address")]
    public string Address { get; set; } = string.Empty;

    public UserRequestBaseModel() { }

    public UserRequestBaseModel(
        UserAccountTypeEnum accountType,
        string firstName,
        string lastName,
        string password,
        string email,
        string phoneNumber,
        string address)
    {
        AccountType = accountType;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
    }
}
