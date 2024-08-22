using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Auth;

public class ConfirmEmail(AuthRepo authRepo) : EndpointWithoutRequest
{
    private readonly AuthRepo _authRepo = authRepo;

    public override void Configure() {
        Put(ApiRoutes.Auth.ConfirmEmail + ApiRoutes.IdParam);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var userId = Route<Guid>(ApiRoutes.IdParam);
        var user = await _authRepo.GetUser(userId);
        if (user == null) {
            // HANDLE_ERROR -> utente non registrato 401 + mex ? 
        }
        user.EmailConfirmed = true;
        await _authRepo.Update(user);
    }
}
