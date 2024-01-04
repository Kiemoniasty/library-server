using Library_WebServer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Library_WebServer.Models;
public class User 
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [ForeignKey(nameof(UserAccountType) + ".Id")]
    public UserAccountType UserAccountType { get; set; }

    [Required]
    [NotNull]
    public string Name { get; set; } = string.Empty;

    [Required]
    [NotNull]
    public string Password {  get; set; } = string.Empty;

    [Required]
    [NotNull]
    public string Email { get; set; } = string.Empty;

    [Required]
    [NotNull]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [NotNull]
    public string Address { get; set; } = string.Empty;

    public User() { }

    public User(Guid id, UserAccountType accountType, string name, string password, string email, string phoneNumber, string address)
    {
        Id = id;
        UserAccountType = accountType;
        Name = name;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
    }
}
