using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Library_WebServer.Models;

public class LibraryAuthor
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

    public LibraryAuthor() { }
    public LibraryAuthor(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}
