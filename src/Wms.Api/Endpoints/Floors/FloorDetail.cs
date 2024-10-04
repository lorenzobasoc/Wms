using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Floors;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Floors;

public class FloorDetail : EndpointWithoutRequest<FloorDetailDto>
{
    public FloorRepo FloorRepo { get; set; } 

    public override void Configure() {
        Get(ApiRoutes.Floors.Detail + ApiRoutes.IdParam);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var floorId = Route<Guid>("Id");
        var floor = await FloorRepo.Find(floorId);
        if (floor == null) {
            await SendNotFoundAsync(ct);
        }
        var dto = floor.ToFloorDetail();
        await SendAsync(dto, cancellation: ct);
    }
}
