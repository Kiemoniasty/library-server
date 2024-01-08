using Library_WebServer.Enums;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Database;

public class PublicationStatusDbModel : EnumTableDbModel<LibraryObjectStatusEnum>
{
    public PublicationStatusDbModel(LibraryObjectStatusEnum @enum) : base(@enum)
    { }

    [JsonConstructor]
    public PublicationStatusDbModel(LibraryObjectStatusEnum id, string name) : base(id, name)
    { }
    protected PublicationStatusDbModel() { }
}