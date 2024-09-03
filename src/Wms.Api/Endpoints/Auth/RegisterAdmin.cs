using Microsoft.AspNetCore.Identity;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class RegisterAdmin(UserRepo userRepo, IPasswordHasher<User> hasher) : Endpoint<RegisterRequest>
{
    private readonly UserRepo _userRepo = userRepo;
    private readonly IPasswordHasher<User> _hasher = hasher;

    public override void Configure() {
        Post(ApiRoutes.Auth.RegisterAdmin);
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct) {
        var user = await _userRepo.Find(req.Email);
        if (user != null) {
            // HANDLE_ERROR -> utente già registrato 401 + mex ? 
        }
        user = new User {
            Email = req.Email,
            Name = req.Name,
            Surname = req.Surname,
            Role = Constants.Authorization.Roles.ADMIN,
            EmailConfirmed = false,
            Disabled = false,
        };
        var hash = _hasher.HashPassword(user, req.Password);
        user.PasswordHash = hash;
        await _userRepo.Create(user);
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
