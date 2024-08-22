using Microsoft.AspNetCore.Identity;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class ConfimWorkerAccount(AuthRepo authRepo, IPasswordHasher<User> hasher) : Endpoint<ConfimWorkerAccountRequest>
{
    private readonly AuthRepo _authRepo = authRepo;
    private readonly IPasswordHasher<User> _hasher = hasher;


    public override void Configure() {
        Post(ApiRoutes.Auth.ConfimWorkerAccount + ApiRoutes.IdParam);
        AllowAnonymous();
    }

    public override async Task HandleAsync(ConfimWorkerAccountRequest req, CancellationToken ct) {
        var userId = Route<Guid>(ApiRoutes.IdParam);
        var user = await _authRepo.GetUser(userId);
        if (user == null) {
            // HANDLE_ERROR -> utente già registrato 401 + mex ? 
        }
        var hash = _hasher.HashPassword(user, req.Password);
        user.PasswordHash = hash;
        await _authRepo.Update(user);
        await SendOkAsync(cancellation: ct);
    }
}

public class ConfimWorkerAccountRequest
{
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
