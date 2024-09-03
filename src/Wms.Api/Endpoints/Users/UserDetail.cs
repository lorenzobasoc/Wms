using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Users;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Users;

public class UserDetail(UserRepo userRepo) : EndpointWithoutRequest<UserDetailDto>
{
    private readonly UserRepo _userRepo = userRepo;

    public override void Configure() {
        Get(ApiRoutes.Users.Detail + ApiRoutes.IdParam);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var userId = Route<Guid>(ApiRoutes.IdParam);
        var user = await _userRepo.Find(userId);
        if (user == null) {
            // HANDLE_ERROR -> utente non trovato 404 + mex 
        }
        var dto = user.ToUserDetail();
        await SendAsync(dto, cancellation: ct);
    }
}
