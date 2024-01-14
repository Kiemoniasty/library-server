using Library_WebServer.Models.Enums.Database;
using Library_WebServer.Models.Rental.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Library_WebServer.Models.User.Database;
public class UserDbModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [ForeignKey(nameof(UserAccountType) + ".Id")]
    public UserAccountTypeDbModel UserAccountType { get; set; }

    [Required]
    [NotNull]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [NotNull]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [NotNull]
    public string Password { get; set; } = string.Empty;

    [Required]
    [NotNull]
    public string Email { get; set; } = string.Empty;

    [Required]
    [NotNull]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [NotNull]
    public string Address { get; set; } = string.Empty;

    public List<RentalDbModel> LibraryRentals { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public UserDbModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public UserDbModel(
        Guid id,
        UserAccountTypeDbModel accountType,
        string firstName,
        string lastName,
        string password,
        string email,
        string phoneNumber,
        string address,
        List<RentalDbModel> rentals)
    {
        Id = id;
        UserAccountType = accountType;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        LibraryRentals = rentals;
    }
}
