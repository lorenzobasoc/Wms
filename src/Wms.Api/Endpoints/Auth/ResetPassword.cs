using Microsoft.AspNetCore.Identity;
using Wms.Api.Dtos.Auth;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class ResetPassword(UserRepo userRepo, IPasswordHasher<User> hasher) : Endpoint<SetPasswordDto>
{
    private readonly UserRepo _userRepo = userRepo;
    private readonly IPasswordHasher<User> _hasher = hasher;


    public override void Configure() {
        Post(ApiRoutes.Auth.ResetPassword + ApiRoutes.IdParam);
        AllowAnonymous();
    }

    public override async Task HandleAsync(SetPasswordDto req, CancellationToken ct) {
        var userId = Route<Guid>(ApiRoutes.IdParam);
        var user = await _userRepo.Find(userId);
        if (user == null) {
            // HANDLE_ERROR -> utente già registrato 401 + mex ? 
        }
        var hash = _hasher.HashPassword(user, req.Password);
        user.PasswordHash = hash;
        await _userRepo.Update(user);
        await SendOkAsync(cancellation: ct);
    }
}
