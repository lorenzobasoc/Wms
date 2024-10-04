using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Users;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Users;

public class WorkerList : EndpointWithoutRequest<List<UserDetailDto>>
{
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Get(ApiRoutes.Users.WorkersList);
        Policies(AppPolicies.ADMIN_POLICY);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var users = await UserRepo.List([ Constants.Authorization.Roles.WORKER ]);
        var res = users
            .Select(u => new UserDetailDto {
                Id = u.Id,
                Name = u.Name,
                Surname = u.Surname,
                Email = u.Email,
            })
            .ToList();
        await SendAsync(res, cancellation: ct);
    }
}
