using Wms.Api.Dtos;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class ConfirmEmail : Endpoint<IdDto>
{
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Put(ApiRoutes.Auth.ConfirmEmail);
        AllowAnonymous();
    }

    public override async Task HandleAsync(IdDto req, CancellationToken ct) {
        var userId = req.Id;
        var user = await UserRepo.Find(userId);
        if (user == null) {
            await SendNotFoundAsync(ct);
        }
        user.EmailConfirmed = true;
        await UserRepo.Update(user);
        await SendOkAsync(cancellation: ct);
    }
}
