using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Library_WebServer.Models.Publication.Database;
using Library_WebServer.Models.User.Database;

namespace Library_WebServer.Models.Comment.Database;

public class CommentDbModel
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
    public PublicationDbModel LibraryPublication { get; set; }

    [Required]
    [ForeignKey(nameof(LibraryUser) + ".Id")]
    public UserDbModel LibraryUser { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public CommentDbModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public CommentDbModel(
        Guid id,
        ushort grade,
        string contents,
        PublicationDbModel publication,
        UserDbModel user)
    {
        Id = id;
        Grade = grade;
        Contents = contents;
        LibraryPublication = publication;
        LibraryUser = user;
    }
}
