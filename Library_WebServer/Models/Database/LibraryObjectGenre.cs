using Library_WebServer.Enums;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Database;

public class LibraryObjectGenre : EnumTable<LibraryObjectGenreEnum>
{
    public LibraryObjectGenre(LibraryObjectGenreEnum @enum) : base(@enum)
    { }

    [JsonConstructor]
    public LibraryObjectGenre(LibraryObjectGenreEnum id, string name) : base(id, name)
    { }
    protected LibraryObjectGenre() { }
}