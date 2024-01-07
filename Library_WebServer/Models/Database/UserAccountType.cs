using Library_WebServer.Enums;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Database;

public class UserAccountType : EnumTable<UserAccountTypeEnum>
{
    public UserAccountType(UserAccountTypeEnum @enum) : base(@enum)
    { }

    [JsonConstructor]
    public UserAccountType(UserAccountTypeEnum id, string name) : base(id, name)
    { }

    protected UserAccountType() { }
}