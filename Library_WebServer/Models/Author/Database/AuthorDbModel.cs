using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Library_WebServer.Models.Author.Database;

public class AuthorDbModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [NotNull]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [NotNull]
    public string LastName { get; set; } = string.Empty;

    public AuthorDbModel() { }
    public AuthorDbModel(
        Guid id,
        string firstName,
        string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}
