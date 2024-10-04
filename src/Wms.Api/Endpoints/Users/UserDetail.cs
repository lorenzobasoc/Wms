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
        var userId = Route<Guid>("Id");
        var user = await UserRepo.Find(userId);
        if (user == null) {
            await SendNotFoundAsync(ct);
        }
        var dto = user.ToUserDetail();
        await SendAsync(dto, cancellation: ct);
    }
}
