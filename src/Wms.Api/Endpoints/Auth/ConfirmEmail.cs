using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class ConfirmEmail(UserRepo userRepo) : EndpointWithoutRequest
{
    private readonly UserRepo _userRepo = userRepo;

    public override void Configure() {
        Put(ApiRoutes.Auth.ConfirmEmail + ApiRoutes.IdParam);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var userId = Route<Guid>(ApiRoutes.IdParam);
        var user = await _userRepo.Find(userId);
        if (user == null) {
            // HANDLE_ERROR -> utente non registrato 401 + mex ? 
        }
        user.EmailConfirmed = true;
        await _userRepo.Update(user);
        await SendOkAsync(cancellation: ct);
    }
}
