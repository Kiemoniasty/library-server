using Library_WebServer.Models.Requests;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Database;

public class PublicationDbModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [NotNull]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [ForeignKey(nameof(LibraryAuthor) + ".Id")]
    public AuthorDbModel LibraryAuthor { get; set; }

    [Required]
    [ForeignKey(nameof(LibraryObjectType) + ".Id")]
    public PublicationTypeDbModel LibraryObjectType { get; set; }

    [Required]
    [ForeignKey(nameof(LibraryObjectGenre) + ".Id")]
    public virtual PublicationGenreDbModel LibraryObjectGenre { get; set; }

    [Required]
    [ForeignKey(nameof(LibraryObjectStatus) + ".Id")]
    public virtual PublicationStatusDbModel LibraryObjectStatus { get; set; }

    public List<ReservationDbModel> LibraryReservations { get; set; }

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
        List<ReservationDbModel> reservations)
    {
        Id = id;
        Name = name;
        LibraryAuthor = libraryAuthor;
        LibraryObjectType = objectType;
        LibraryObjectGenre = genre;
        LibraryObjectStatus = status;
        LibraryReservations = reservations;
    }
}