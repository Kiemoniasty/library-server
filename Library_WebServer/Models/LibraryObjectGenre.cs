using Library_WebServer.Enums;

namespace Library_WebServer.Models;

public class LibraryObjectGenre : EnumTable<LibraryObjectGenreEnum>
{
    public LibraryObjectGenre(LibraryObjectGenreEnum @enum) : base(@enum)
    { }

    protected LibraryObjectGenre() { }
}