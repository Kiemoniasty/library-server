using Library_WebServer.Enums;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models;

public class LibraryObjectType : EnumTable<LibraryObjectTypeEnum>
{
    public LibraryObjectType(LibraryObjectTypeEnum @enum) : base(@enum)
    { }
    [JsonConstructor]
    public LibraryObjectType(LibraryObjectTypeEnum id, string name) : base(id, name)
    { }
    protected LibraryObjectType() { }
}
