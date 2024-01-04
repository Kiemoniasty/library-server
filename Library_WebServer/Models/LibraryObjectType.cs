using Library_WebServer.Enums;

namespace Library_WebServer.Models;

public class LibraryObjectType : EnumTable<LibraryObjectTypeEnum>
{
    public LibraryObjectType(LibraryObjectTypeEnum @enum) : base(@enum)
    { }

    protected LibraryObjectType() { }
}
