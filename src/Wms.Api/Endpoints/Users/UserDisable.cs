using Wms.Api.Authorization;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Users;

public class UserDisable(UserRepo userRepo) : EndpointWithoutRequest
{
    private readonly UserRepo _userRepo = userRepo;

    public override void Configure() {
        Put(ApiRoutes.Users.Delete + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var userId = Route<Guid>(ApiRoutes.IdParam);
        var user = await _userRepo.GetUser(userId);
        if (user == null) {
            // HANDLE_ERROR -> utente non trovato 404 + mex ? 
        }
        user.Disabled = true;
        user.DisablingDate = DateTime.Now;
        await _userRepo.Update(user);
        await SendOkAsync(cancellation: ct);
    }
}
