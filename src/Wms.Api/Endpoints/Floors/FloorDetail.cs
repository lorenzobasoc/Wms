using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Floors;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Floors;

public class FloorDetail(FloorRepo floorRepo) : EndpointWithoutRequest<FloorDetailDto>
{
    private readonly FloorRepo _floorRepo = floorRepo;

    public override void Configure() {
        Get(ApiRoutes.Floors.Detail + ApiRoutes.IdParam);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var floorId = Route<Guid>(ApiRoutes.IdParam);
        var floor = await _floorRepo.Find(floorId);
        if (floor == null) {
            // HANDLE_ERROR -> utente non trovato 404 + mex occhio che c'è il SingleOrThrow
        }
        var dto = floor.ToFloorDetail();
        await SendAsync(dto, cancellation: ct);
    }
}
