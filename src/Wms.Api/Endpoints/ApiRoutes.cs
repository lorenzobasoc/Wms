namespace Wms.Api.Endpoints;

public class ApiRoutes
{
    public const string IdParam = "/{Id}";
    public const string FloorIdParam = "/{FloorId}";
    
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

    public class Rooms
    {
        private const string _base = _api + "/rooms";
        public const string List = _base + "/list";
        public const string Detail = _base + "/detail";
        public const string DetailWithSeats = _base + "/detail-with-seats";
        public const string Edit = _base + "/edit";
        public const string Delete = _base + "/delete";
    }

    public class Tables
    {
        private const string _base = _api + "/tables";
        public const string List = _base + "/list";
        public const string Detail = _base + "/detail";
        public const string DetailWithSeats = _base + "/detail-with-seats";
        public const string Edit = _base + "/edit";
        public const string Delete = _base + "/delete";
    }

    public class Seats
    {
        private const string _base = _api + "/seats";
        public const string List = _base + "/list";
        public const string Edit = _base + "/edit";
        public const string Delete = _base + "/delete";
    }

    public class Bookings
    {
        private const string _base = _api + "/bookings";
        public const string List = _base + "/list";
        public const string ListActives = _base + "/list-actives";
        public const string ListClosed = _base + "/list-closed";
        public const string Edit = _base + "/edit";
        public const string Delete = _base + "/delete";
    }
}
