using Microsoft.AspNetCore.Identity;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class RegisterWorker(AuthRepo authRepo) : Endpoint<RegisterWorkerRequest>
{
    private readonly AuthRepo _authRepo = authRepo;

    public override void Configure() {
        Post(ApiRoutes.Auth.RegisterUser);
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterWorkerRequest req, CancellationToken ct) {
        var user = await _authRepo.GetUser(req.Email);
        if (user != null) {
            // HANDLE_ERROR -> utente già registrato 401 + mex ? 
        }
        user = new User {
            Email = req.Email,
            Name = req.Name,
            Surname = req.Surname,
            Role = Authorization.Roles.WORKER,
            EmailConfirmed = false,
        };
        await _authRepo.Create(user);
        await SendOkAsync(cancellation: ct);
    }
}

public class RegisterWorkerRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}
