using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Enums.Database;

public class PublicationStatusDbModel : EnumTableDbModel<LibraryObjectStatusEnum>
{
    public PublicationStatusDbModel(LibraryObjectStatusEnum @enum) : base(@enum)
    { }

    [JsonConstructor]
    public PublicationStatusDbModel(LibraryObjectStatusEnum id, string name) : base(id, name)
    { }
    protected PublicationStatusDbModel() { }
}