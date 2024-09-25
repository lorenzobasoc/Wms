using Microsoft.AspNetCore.Identity;
using Wms.Api.Dtos.Auth;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class RegisterAdmin : Endpoint<RegisterDto>
{
    public UserRepo UserRepo { get; set; }
    public IPasswordHasher<User> Hasher { get; set; }

    public override void Configure() {
        Post(ApiRoutes.Auth.RegisterAdmin);
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterDto req, CancellationToken ct) {
        var user = await UserRepo.Find(req.Email);
        if (user != null) {
            ThrowError(r => r.Email, "Email already used.");
        }

        user = new User {
            Email = req.Email,
            Name = req.Name,
            Surname = req.Surname,
            Role = Constants.Authorization.Roles.ADMIN,
            EmailConfirmed = false,
            Disabled = false,
        };
        var hash = Hasher.HashPassword(user, req.Password);
        user.PasswordHash = hash;
        await UserRepo.Create(user);
        await SendOkAsync(cancellation: ct);
    }
}
