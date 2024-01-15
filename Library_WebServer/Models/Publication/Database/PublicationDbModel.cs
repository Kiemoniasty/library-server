using Library_WebServer.Models.Author.Database;
using Library_WebServer.Models.Comment.Database;
using Library_WebServer.Models.Enums.Database;
using Library_WebServer.Models.Rental.Database;
using Library_WebServer.Models.Reservation.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Library_WebServer.Models.Publication.Database;

public class PublicationDbModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [NotNull]
    public string Name { get; set; } = string.Empty;

    [Required]
    [NotNull]
    public string Description { get; set; } = string.Empty;

    [Required]
    [NotNull]
    public DateTime ReleaseYear { get; set; }

    [Required]
    [ForeignKey(nameof(LibraryAuthor) + ".Id")]
    public AuthorDbModel LibraryAuthor { get; set; }

    [Required]
    [ForeignKey(nameof(LibraryObjectType) + ".Id")]
    public virtual PublicationTypeDbModel LibraryObjectType { get; set; }

    [Required]
    [ForeignKey(nameof(LibraryObjectGenre) + ".Id")]
    public virtual PublicationGenreDbModel LibraryObjectGenre { get; set; }

    [Required]
    [ForeignKey(nameof(LibraryObjectStatus) + ".Id")]
    public virtual PublicationStatusDbModel LibraryObjectStatus { get; set; }

    public List<ReservationDbModel> LibraryReservations { get; set; }

    public List<CommentDbModel> LibraryComments { get; set; }

    public List<RentalDbModel> LibraryRentals { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public PublicationDbModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public PublicationDbModel(
        Guid id,
        string name,
        AuthorDbModel libraryAuthor,
        PublicationTypeDbModel objectType,
        PublicationGenreDbModel genre,
        PublicationStatusDbModel status,
        List<ReservationDbModel> reservations,
        List<CommentDbModel> comments,
        List<RentalDbModel> rentals)
    {
        Id = id;
        Name = name;
        LibraryAuthor = libraryAuthor;
        LibraryObjectType = objectType;
        LibraryObjectGenre = genre;
        LibraryObjectStatus = status;
        LibraryReservations = reservations;
        LibraryComments = comments;
        LibraryRentals = rentals;
    }
}