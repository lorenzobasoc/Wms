using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Wms.Api.Dtos.Auth;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class Login : Endpoint<LoginDto>
{
    public UserRepo UserRepo { get; set; }
    public IPasswordHasher<User> Hasher { get; set; }

    public override void Configure() {
        Post(ApiRoutes.Auth.Login);
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginDto req, CancellationToken ct) {
        var user = await UserRepo.Find(req.Email);
        if (user == null) {
            ThrowError(l => l.Email, "No account found with this email.");
        }
        if (user.Disabled) {
            ThrowError(l => l.Email, "Account disabled.");
        }
        if (!user.EmailConfirmed) {
            ThrowError(l => l.Email, "Email not confirmed, please confirm your account.");
        }
        CheckPassword(user, user.PasswordHash, req.Password);

        await CookieAuth.SignInAsync(u => SetupLoggedUser(u, user));
        await SendOkAsync(cancellation: ct);
    }

    private void CheckPassword(User user, string hashedPassword, string providedPassword) {
        var result = Hasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
        if (result != PasswordVerificationResult.Success) {
            ThrowError(l => l.Password, "Wrong password.");
        }
    }

    private static void SetupLoggedUser(UserPrivileges up, User user) {
        // up.Claims.Add(new("Address", "123 Street"));

        up[ClaimTypes.Role] = user.Role;
        up[ClaimTypes.Name] = user.Email;
    }
}

