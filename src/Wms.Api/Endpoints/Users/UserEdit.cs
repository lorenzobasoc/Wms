using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Users;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Users;

public class UserEdit(UserRepo userRepo) : Endpoint<UserEditDto>
{
    private readonly UserRepo _userRepo = userRepo;

    public override void Configure() {
        Put(ApiRoutes.Users.Edit + ApiRoutes.IdParam);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(UserEditDto req, CancellationToken ct) {
        var userId = Route<Guid>(ApiRoutes.IdParam);
        var user = await _userRepo.Find(userId);
        if (user == null) {
            // HANDLE_ERROR -> utente non registrato 401 + mex ? 
        }
        UpdateProperties(user, req);
        await _userRepo.Update(user);
        await SendOkAsync(cancellation: ct);
    }

    private static void UpdateProperties(User user, UserEditDto req) {
        user.Photo.Data = req.Photo;
    }
}
