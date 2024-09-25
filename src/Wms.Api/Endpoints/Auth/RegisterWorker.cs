using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Auth;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class RegisterWorker : Endpoint<RegisterWorkerDto>
{
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Post(ApiRoutes.Auth.RegisterWorker);
        Policies(AppPolicies.ADMIN_POLICY);
    }

    public override async Task HandleAsync(RegisterWorkerDto req, CancellationToken ct) {
        var user = await UserRepo.Find(req.Email);
        if (user != null) {
            ThrowError(r => r.Email, "Email already used.");
        }
        user = new User {
            Email = req.Email,
            Name = req.Name,
            Surname = req.Surname,
            Role = Constants.Authorization.Roles.WORKER,
            EmailConfirmed = false,
            Disabled = false,
        };
        await UserRepo.Create(user);
        await SendOkAsync(cancellation: ct);
    }
}
