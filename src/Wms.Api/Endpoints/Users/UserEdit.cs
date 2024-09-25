using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Users;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Users;

public class UserEdit : Endpoint<UserEditDto>
{
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Put(ApiRoutes.Users.Edit + ApiRoutes.IdParam);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(UserEditDto req, CancellationToken ct) {
        var userId = Route<Guid>(ApiRoutes.IdParam);
        var user = await UserRepo.Find(userId);
        if (user == null) {
            await SendNotFoundAsync(ct);
        }
        UpdateProperties(user, req);
        await UserRepo.Update(user);
        await SendOkAsync(cancellation: ct);
    }

    private static void UpdateProperties(User user, UserEditDto req) {
        user.Photo.Data = req.Photo ?? user.Photo.Data;
    }
}
