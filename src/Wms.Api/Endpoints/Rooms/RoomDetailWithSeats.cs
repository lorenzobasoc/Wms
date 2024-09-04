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
            // HANDLE_ERROR -> utente non trovato 404 + mex occhio che c'è il SingleOrThrow
        }
        var dto = room.ToRoomDetail();
        await SendAsync(dto, cancellation: ct);
    }
}
