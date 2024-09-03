using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Floors;

public class FloorList(FloorRepo floorRepo) : EndpointWithoutRequest<ListItemDto[]>
{
    private readonly FloorRepo _floorRepo = floorRepo;

    public override void Configure() {
        Get(ApiRoutes.Floors.List);
        Policies(AppPolicies.WORKER_POLICY);
    }

    public override async Task<ListItemDto[]> HandleAsync(CancellationToken ct) {
        var floors = await _floorRepo.List();
        var res = floors
            .Select(u => new ListItemDto {
                Id = u.Id,
                Description = u.Name
            })
            .ToArray();
        return res;
    }
}
