using Wms.Api.Authorization;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class RegisterWorker(UserRepo userRepo) : Endpoint<RegisterWorkerRequest>
{
    private readonly UserRepo _userRepo = userRepo;

    public override void Configure() {
        Post(ApiRoutes.Auth.RegisterWorker);
        Policies(AppPolicies.ADMIN_POLICY);

    }

    public override async Task HandleAsync(RegisterWorkerRequest req, CancellationToken ct) {
        var user = await _userRepo.GetUser(req.Email);
        if (user != null) {
            // HANDLE_ERROR -> utente già registrato 401 + mex ? 
        }
        user = new User {
            Email = req.Email,
            Name = req.Name,
            Surname = req.Surname,
            Role = Authorization.Roles.WORKER,
            EmailConfirmed = false,
            Disabled = false,
        };
        await _userRepo.Create(user);
        await SendOkAsync(cancellation: ct);
    }
}

public class RegisterWorkerRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}
