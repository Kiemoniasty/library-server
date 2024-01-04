using Library_WebServer.Enums;

namespace Library_WebServer.Models;

public class UserAccountType : EnumTable<UserAccountTypeEnum>
{
    public UserAccountType(UserAccountTypeEnum @enum) : base(@enum)
    { }

    protected UserAccountType() { }
}