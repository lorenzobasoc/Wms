namespace Wms.Api.Endpoints;

public class ApiRoutes
{
    public const string IdParam = "/{Id}";
    
    private const string _api = "/api";

    public class Auth
    {
        private const string _base = _api + "/auth";
        public const string Login = _base + "/login";
        public const string Logout = _base + "/logout";
        public const string RegisterAdmin = _base + "/register-admin";
        public const string RegisterWorker = _base + "/register-user";
        public const string ConfirmEmail = _base + "/confirm-email";
        public const string ResetPassword = _base + "/reset-password";
    }

    public class Users
    {
        private const string _base = _api + "/users";
        public const string WorkersList = _base + "/workers-list";
        public const string Detail = _base + "/detail";
        public const string Edit = _base + "/edit";
        public const string Delete = _base + "/delete";
    }

    public class Floors
    {
        private const string _base = _api + "/floors";
        public const string List = _base + "/list";
        public const string Detail = _base + "/detail";
        public const string Edit = _base + "/edit";
        public const string Delete = _base + "/delete";
    }
}
