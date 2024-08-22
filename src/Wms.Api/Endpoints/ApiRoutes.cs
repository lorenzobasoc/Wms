namespace Wms.Api.Endpoints;

public class ApiRoutes
{
    private const string _api = "/api";

    public class Auth
    {
        private const string _base = _api + "/auth";
        public const string Login = _base + "/login";
        public const string Logout = _base + "/logout";
    }
}
