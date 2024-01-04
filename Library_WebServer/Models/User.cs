using Library_WebServer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models;
public class User 
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [ForeignKey(nameof(UserAccountType) + ".Id")]
    [JsonPropertyName("UserAccountType")]
    public UserAccountType UserAccountType { get; set; }

    [Required]
    [NotNull]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [NotNull]
    [JsonPropertyName("Password")]
    public string Password {  get; set; } = string.Empty;

    [Required]
    [NotNull]
    [JsonPropertyName("Email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [NotNull]
    [JsonPropertyName("PhoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [NotNull]
    [JsonPropertyName("Address")]
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
