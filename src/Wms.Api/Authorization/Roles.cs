namespace Wms.Api.Authorization;

public class Roles
{
    public const string ADMIN = "Admin";
    public const string USER = "User";

     public static readonly IEnumerable<string> ALL = [
       ADMIN, USER
    ];
}
