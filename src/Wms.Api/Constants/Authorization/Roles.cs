namespace Wms.Api.Constants.Authorization;

public class Roles
{
    public const string ADMIN = "Admin";
    public const string WORKER = "Worker";

    public static readonly IEnumerable<string> ALL = [
       ADMIN, WORKER
    ];
}
