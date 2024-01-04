using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models;

public class LibraryReservation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [NotNull]
    public DateTime Date{ get; set; }

    [Required]
    [ForeignKey(nameof(LibraryPublication) + ".Id")]
    public Guid LibraryPublication {  get; set; }

    [Required]
    [ForeignKey(nameof(User) + ".Id")]
    public Guid User { get; set; }

    public LibraryReservation() { }

    public LibraryReservation(Guid id, DateTime date, Guid publicationId, Guid userId)
    {
        Id = id;
        Date = date;
        LibraryPublication = publicationId;
        User = userId;
    }
}
