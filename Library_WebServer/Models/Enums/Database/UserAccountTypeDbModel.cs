using Library_WebServer.Enums;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Enums.Database;

public class UserAccountTypeDbModel : EnumTableDbModel<UserAccountTypeEnum>
{
    public UserAccountTypeDbModel(UserAccountTypeEnum @enum) : base(@enum)
    { }

    [JsonConstructor]
    public UserAccountTypeDbModel(UserAccountTypeEnum id, string name) : base(id, name)
    { }

    protected UserAccountTypeDbModel() { }
}