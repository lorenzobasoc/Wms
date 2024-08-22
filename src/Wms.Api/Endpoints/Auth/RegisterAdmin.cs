using Microsoft.AspNetCore.Identity;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class RegisterAdmin(AuthRepo authRepo, IPasswordHasher<User> hasher) : Endpoint<RegisterRequest>
{
    private readonly AuthRepo _authRepo = authRepo;
    private readonly IPasswordHasher<User> _hasher = hasher;

    public override void Configure() {
        Post(ApiRoutes.Auth.RegisterAdmin);
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct) {
        var user = await _authRepo.GetUser(req.Email);
        if (user != null) {
            // HANDLE_ERROR -> utente già registrato 401 + mex ? 
        }
        user = new User {
            Email = req.Email,
            Name = req.Name,
            Surname = req.Surname,
            Role = Authorization.Roles.ADMIN,
            EmailConfirmed = true, // TODO: confirmation mail
        };
        var hash = _hasher.HashPassword(user, req.Password);
        user.PasswordHash = hash;
        await _authRepo.Create(user);
        await SendOkAsync(cancellation: ct);
    }
}

public class RegisterRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
