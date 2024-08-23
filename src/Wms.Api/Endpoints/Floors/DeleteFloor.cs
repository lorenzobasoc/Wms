using Wms.Api.Authorization;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Floors;

public class DeleteFloor(FloorRepo floorRepo) : EndpointWithoutRequest
{
    private readonly FloorRepo _floorRepo = floorRepo;

    public override void Configure() {
        Delete(ApiRoutes.Floors.Delete + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var floorId = Route<Guid>(ApiRoutes.IdParam);
        var floor = await _floorRepo.GetFloor(floorId);
        if (floor == null) {
            // HANDLE_ERROR -> floor non trovato 404 + mex ? c'è single or throw
        }
        
        await _floorRepo.Delete(floor);
        await SendOkAsync(cancellation: ct);
    }
}
