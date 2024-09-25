using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Rooms;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Rooms;

public class RoomDetailWithSeats : EndpointWithoutRequest<RoomDetailDto>
{
    public RoomRepo RoomRepo { get; set; }

    public override void Configure() {
        Get(ApiRoutes.Rooms.DetailWithSeats + ApiRoutes.IdParam);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var roomId = Route<Guid>(ApiRoutes.IdParam);
        var room = await RoomRepo.FindWithSeats(roomId);
        if (room == null) {
            await SendNotFoundAsync(ct);
        }
        var dto = room.ToRoomDetail();
        await SendAsync(dto, cancellation: ct);
    }
}
