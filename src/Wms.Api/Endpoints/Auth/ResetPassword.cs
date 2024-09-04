using Microsoft.AspNetCore.Identity;
using Wms.Api.Dtos.Auth;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class ResetPassword : Endpoint<SetPasswordDto>
{
    public UserRepo UserRepo { get; set; }
    public IPasswordHasher<User> Hasher { get; set; }


    public override void Configure() {
        Post(ApiRoutes.Auth.ResetPassword + ApiRoutes.IdParam);
        AllowAnonymous();
    }

    public override async Task HandleAsync(SetPasswordDto req, CancellationToken ct) {
        var userId = Route<Guid>(ApiRoutes.IdParam);
        var user = await UserRepo.Find(userId);
        if (user == null) {
            // HANDLE_ERROR -> utente già registrato 401 + mex ? 
        }
        var hash = Hasher.HashPassword(user, req.Password);
        user.PasswordHash = hash;
        await UserRepo.Update(user);
        await SendOkAsync(cancellation: ct);
    }
}
