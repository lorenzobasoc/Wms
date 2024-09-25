using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Users;

public class WorkerList : EndpointWithoutRequest<List<ListItemDto>>
{
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Get(ApiRoutes.Users.WorkersList);
        Policies(AppPolicies.ADMIN_POLICY);
    }

    public override async Task<List<ListItemDto>> HandleAsync(CancellationToken ct) {
        var users = await UserRepo.List([Constants.Authorization.Roles.WORKER]);
        var res = users
            .Select(u => new ListItemDto {
                Id = u.Id,
                Description = u.Email
            })
            .ToList();
        return res;
    }
}
