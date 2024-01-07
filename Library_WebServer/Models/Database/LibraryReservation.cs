using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Library_WebServer.Models.Database;

public class LibraryReservation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [NotNull]
    public DateTime Date { get; set; }

    [Required]
    [ForeignKey(nameof(LibraryPublication) + ".Id")]
    public LibraryPublication LibraryPublication { get; set; }

    [Required]
    [ForeignKey(nameof(LibraryUser) + ".Id")]
    public LibraryUser LibraryUser { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public LibraryReservation() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public LibraryReservation(
        Guid id, 
        DateTime date, 
        LibraryPublication publication, 
        LibraryUser user)
    {
        Id = id;
        Date = date;
        LibraryPublication = publication;
        LibraryUser = user;
    }
}
