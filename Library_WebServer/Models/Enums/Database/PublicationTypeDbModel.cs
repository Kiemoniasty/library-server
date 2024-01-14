using Library_WebServer.Enums;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Enums.Database;

public class PublicationTypeDbModel : EnumTableDbModel<LibraryObjectTypeEnum>
{
    public PublicationTypeDbModel(LibraryObjectTypeEnum @enum) : base(@enum)
    { }

    [JsonConstructor]
    public PublicationTypeDbModel(LibraryObjectTypeEnum id, string name) : base(id, name)
    { }
    protected PublicationTypeDbModel() { }
}
