using Library_WebServer.Models.Enums;
using Library_WebServer.Models.Rental.Response;
using Library_WebServer.Models.User.Database;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.User.Response;

public class UserResponseModel : UserResponseBaseModel
{
    [JsonPropertyName("Rentals")]
    public List<RentalResponseModel> Rentals { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public UserResponseModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public UserResponseModel(UserDbModel user)
    {
        Id = user.Id;
        Name = user.Name;
        Password = user.Password;
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
        Address = user.Address;
        AccountType = user.UserAccountType.Id;
        Rentals = user.LibraryRentals.Select(x => new RentalResponseModel(x)).ToList();
    }

    public UserResponseModel
        (Guid id,
        UserAccountTypeEnum accountType,
        string name,
        string password,
        string email,
        string phoneNumber,
        string address,
        List<RentalResponseModel> rentals) 
        : base (id, accountType, name, password, email, phoneNumber, address)
    {
        Id = id;
        AccountType = accountType;
        Name = name;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        Rentals = rentals;
    }
}
