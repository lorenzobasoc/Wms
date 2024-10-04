using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Rooms;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Rooms;

public class RoomDetail : EndpointWithoutRequest<RoomDetailDto>
{
    public RoomRepo RoomRepo { get; set; }

    public override void Configure() {
        Get(ApiRoutes.Rooms.Detail + ApiRoutes.IdParam);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var roomId = Route<Guid>("Id");
        var room = await RoomRepo.Find(roomId);
        if (room == null) {
            await SendNotFoundAsync(ct);
        }
        var dto = room.ToRoomDetail();
        await SendAsync(dto, cancellation: ct);
    }
}
