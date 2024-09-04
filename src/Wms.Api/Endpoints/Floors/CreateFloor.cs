using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Floors;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Floors;

public class CreateFloor : Endpoint<FloorEditDto>
{
    public FloorRepo FloorRepo { get; set; } 

    public override void Configure() {
        Post(ApiRoutes.Floors.Edit);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(FloorEditDto req, CancellationToken ct) {
        var floor = req.ToEntity();
        await FloorRepo.Create(floor);
        await SendOkAsync(cancellation: ct);
    }
}
