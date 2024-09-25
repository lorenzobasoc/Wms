using Wms.Api.Constants.Authorization;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Floors;

public class DeleteFloor : EndpointWithoutRequest
{
    public FloorRepo FloorRepo { get; set; } 

    public override void Configure() {
        Delete(ApiRoutes.Floors.Delete + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var floorId = Route<Guid>(ApiRoutes.IdParam);
        var floor = await FloorRepo.Find(floorId);
        if (floor == null) {
            await SendNotFoundAsync(ct);
        }
        await FloorRepo.Delete(floor);
        await SendOkAsync(cancellation: ct);
    }
}
