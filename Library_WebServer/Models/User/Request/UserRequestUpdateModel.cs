using Library_WebServer.Enums;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.User.Request;
public class UserRequestUpdateModel : UserRequestBaseModel
{
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }

    public UserRequestUpdateModel() { }

    public UserRequestUpdateModel(
        Guid id,
        UserAccountTypeEnum accountType,
        string firstName,
        string lastName,
        string password,
        string email,
        string phoneNumber,
        string address) : base(accountType, firstName, lastName, password, email, phoneNumber, address)
    {
        Id = id;
    }
}
