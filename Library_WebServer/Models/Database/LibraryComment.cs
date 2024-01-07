using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Library_WebServer.Models.Database;

public class LibraryComment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [NotNull]
    public ushort Grade { get; set; }

    [Required]
    [NotNull]
    public string Contents { get; set; } = string.Empty;

    [Required]
    [ForeignKey(nameof(LibraryPublication) + ".Id")]
    public LibraryPublication LibraryPublication { get; set; }

    [Required]
    [ForeignKey(nameof(LibraryUser) + ".Id")]
    public LibraryUser LibraryUser { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public LibraryComment() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public LibraryComment(
        Guid id, 
        ushort grade, 
        string contents, 
        LibraryPublication publication, 
        LibraryUser user)
    {
        Id = id;
        Grade = grade;
        Contents = contents;
        LibraryPublication = publication;
        LibraryUser = user;
    }
}
