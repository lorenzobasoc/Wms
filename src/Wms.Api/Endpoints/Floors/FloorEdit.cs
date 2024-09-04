using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Floors;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Floors;

public class FloorEdit(FloorRepo floorRepo) : Endpoint<FloorEditDto>
{
    private readonly FloorRepo _floorRepo = floorRepo;

    public override void Configure() {
        Put(ApiRoutes.Floors.Edit + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(FloorEditDto req, CancellationToken ct) {
        var floorId = Route<Guid>(ApiRoutes.IdParam);
        var floor = await _floorRepo.Find(floorId);
        if (floor == null) {
            // HANDLE_ERROR -> utente non registrato 401 + mex ? 
        }
        UpdateProperties(floor, req);
        await _floorRepo.Update(floor);
        await SendOkAsync(cancellation: ct);
    }

    private static void UpdateProperties(Floor floor, FloorEditDto req) {
        floor.Name = req.Name ?? floor.Name;
        floor.Description = req.Description ?? floor.Description;
    }
}
