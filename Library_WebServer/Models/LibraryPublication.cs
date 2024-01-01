using Library_WebServer.Enums;

namespace Library_WebServer.Models;

public class LibraryPublication
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public LibraryObjectType LibraryObjectTypeId { get; set; }
    public LibraryObjectGenre LibraryObjectGenreId { get; set; }

    public LibraryPublication() { }
    public LibraryPublication(Guid id, string name, LibraryObjectType objectType, LibraryObjectGenre genre)
    {
        Id = id;
        Name = name;
        LibraryObjectTypeId = objectType;
        LibraryObjectGenreId = genre;
    }
}
