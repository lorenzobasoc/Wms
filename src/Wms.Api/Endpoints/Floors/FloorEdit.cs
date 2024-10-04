using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Floors;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Floors;

public class FloorEdit : Endpoint<FloorEditDto>
{
    public FloorRepo FloorRepo { get; set; } 

    public override void Configure() {
        Put(ApiRoutes.Floors.Edit + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(FloorEditDto req, CancellationToken ct) {
        var floorId = Route<Guid>("Id");
        var floor = await FloorRepo.Find(floorId);
        if (floor == null) {
            await SendNotFoundAsync(ct);
        }
        UpdateProperties(floor, req);
        await FloorRepo.Update(floor);
        await SendOkAsync(cancellation: ct);
    }

    private static void UpdateProperties(Floor floor, FloorEditDto req) {
        floor.Name = req.Name ?? floor.Name;
        floor.Description = req.Description ?? floor.Description;
    }
}
