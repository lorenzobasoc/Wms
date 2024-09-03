using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Users;

public class WorkerList(UserRepo userRepo) : EndpointWithoutRequest<ListItemDto[]>
{
    private readonly UserRepo _userRepo = userRepo;

    public override void Configure() {
        Get(ApiRoutes.Users.WorkersList);
        Policies(AppPolicies.ADMIN_POLICY);
    }

    public override async Task<ListItemDto[]> HandleAsync(CancellationToken ct) {
        var users = await _userRepo.List([Authorization.Roles.WORKER]);
        var res = users
            .Select(u => new ListItemDto {
                Id = u.Id,
                Description = u.Email
            })
            .ToArray();
        return res;
    }
}
