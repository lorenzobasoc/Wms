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
            // HANDLE_ERROR -> utente non registrato 401 + mex ? 
        }
        if (user.Disabled) {
            // HANDLE_ERROR -> utente disabilitato 401 + mex ?
        }
        CheckPassword(user, user.PasswordHash, req.Password);
        await CookieAuth.SignInAsync(u => SetupLoggedUser(u, user));
        await SendOkAsync(cancellation: ct);
    }

    private void CheckPassword(User user, string hashedPassword, string providedPassword) {
        var result = Hasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
        if (result != PasswordVerificationResult.Success) {
            // HANDLE_ERROR -> password errata 401 + mex ? 
        }
    }

    private static void SetupLoggedUser(UserPrivileges up, User user) {
        up.Roles.Add(user.Role);
        up.Claims.Add(new("Address", "123 Street"));
        up[nameof(user.Email)] = user.Email;
        up[nameof(user.Name)] = user.Email;
    }
}

