using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class ConfirmEmail : EndpointWithoutRequest
{
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Put(ApiRoutes.Auth.ConfirmEmail + ApiRoutes.IdParam);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var userId = Route<Guid>(ApiRoutes.IdParam);
        var user = await UserRepo.Find(userId);
        if (user == null) {
            // HANDLE_ERROR -> utente non registrato 401 + mex ? 
        }
        user.EmailConfirmed = true;
        await UserRepo.Update(user);
        await SendOkAsync(cancellation: ct);
    }
}
