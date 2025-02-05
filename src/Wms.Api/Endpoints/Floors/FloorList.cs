using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Floors;

public class FloorList : EndpointWithoutRequest<List<ListItemDto>>
{
    public FloorRepo FloorRepo { get; set; } 

    public override void Configure() {
        Get(ApiRoutes.Floors.List);
        Policies(AppPolicies.WORKER_POLICY);
    }

    public override async Task<List<ListItemDto>> HandleAsync(CancellationToken ct) {
        var floors = await FloorRepo.List();
        var res = floors
            .Select(u => new ListItemDto {
                Id = u.Id,
                Description = u.Name
            })
            .ToList();
        return res;
    }
}
