using Wms.Api.Constants.Authorization;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Users;

public class UserDisable : EndpointWithoutRequest
{
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Put(ApiRoutes.Users.Delete + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var userId = Route<Guid>(ApiRoutes.IdParam);
        var user = await UserRepo.Find(userId);
        if (user == null) {
            // HANDLE_ERROR -> utente non trovato 404 + mex ? 
        }
        user.Disabled = true;
        user.DisablingDate = DateTime.Now;
        await UserRepo.Update(user);
        await SendOkAsync(cancellation: ct);
    }
}
