using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Users;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Users;

public class UserDetail : EndpointWithoutRequest<UserDetailDto>
{
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Get(ApiRoutes.Users.Detail + ApiRoutes.IdParam);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var userId = Route<Guid>(ApiRoutes.IdParam);
        var user = await UserRepo.Find(userId);
        if (user == null) {
            // HANDLE_ERROR -> utente non trovato 404 + mex 
        }
        var dto = user.ToUserDetail();
        await SendAsync(dto, cancellation: ct);
    }
}
