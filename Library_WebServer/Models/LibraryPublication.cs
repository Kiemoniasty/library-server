using Library_WebServer.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models;

public class LibraryPublication
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [NotNull]
    public string Name { get; set; } = string.Empty;

    [Required]
    [ForeignKey(nameof(LibraryObjectType) + ".Id")]
    public LibraryObjectType LibraryObjectType { get; set; }

    [Required]
    [ForeignKey(nameof(LibraryObjectGenre) + ".Id")]
    public virtual LibraryObjectGenre LibraryObjectGenre { get; set; }

    public LibraryPublication() { }

    public LibraryPublication(Guid id, string name, LibraryObjectType objectType, LibraryObjectGenre genre)
    {
        Id = id;
        Name = name;
        LibraryObjectType = objectType;
        LibraryObjectGenre = genre;
    }
}