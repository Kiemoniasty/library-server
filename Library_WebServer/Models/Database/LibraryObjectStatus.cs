using Library_WebServer.Enums;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Database;

public class LibraryObjectStatus : EnumTable<LibraryObjectStatusEnum>
{
    public LibraryObjectStatus(LibraryObjectStatusEnum @enum) : base(@enum)
    { }

    [JsonConstructor]
    public LibraryObjectStatus(LibraryObjectStatusEnum id, string name) : base(id, name)
    { }
    protected LibraryObjectStatus() { }
}