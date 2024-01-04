using Library_WebServer.Enums;

namespace Library_WebServer.Models;

public class LibraryObjectStatus : EnumTable<LibraryObjectStatusEnum>
{
    public LibraryObjectStatus(LibraryObjectStatusEnum @enum) : base(@enum)
    { }

    protected LibraryObjectStatus() { }
}