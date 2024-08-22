using Wms.Api.Authorization;

namespace Wms.Api.Endpoints.Auth;

public class Logout : EndpointWithoutRequest
{
    public override void Configure() {
        Post(ApiRoutes.Auth.Logout);
        Policies(AppPolicies.WORKER_POLICY);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        await CookieAuth.SignOutAsync();
        await SendOkAsync(cancellation: ct);
    }
}
