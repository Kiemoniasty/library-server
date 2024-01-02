using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Library_WebServer.Models;

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
    [ForeignKey(nameof(LibraryPublication))]
    public Guid PublicationId {  get; set; }

    [Required]
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public LibraryComment() { }

    public LibraryComment(Guid id, ushort grade, string contents, Guid publicationId, Guid userId)
    {
        Id = id;
        Grade = grade;
        Contents = contents;
        PublicationId = publicationId;
        UserId = userId;
    }
}
