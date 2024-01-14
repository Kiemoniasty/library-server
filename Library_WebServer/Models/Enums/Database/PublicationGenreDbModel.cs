using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Enums.Database;

public class PublicationGenreDbModel : EnumTableDbModel<LibraryObjectGenreEnum>
{
    public PublicationGenreDbModel(LibraryObjectGenreEnum @enum) : base(@enum)
    { }

    [JsonConstructor]
    public PublicationGenreDbModel(LibraryObjectGenreEnum id, string name) : base(id, name)
    { }
    protected PublicationGenreDbModel() { }
}