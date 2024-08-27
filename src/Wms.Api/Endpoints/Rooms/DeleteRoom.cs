using Wms.Api.Authorization;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Rooms;

public class DeleteRoom(RoomRepo roomRepo) : EndpointWithoutRequest
{
    private readonly RoomRepo _roomRepo = roomRepo;

    public override void Configure() {
        Delete(ApiRoutes.Rooms.Delete + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var roomId = Route<Guid>(ApiRoutes.IdParam);
        var room = await _roomRepo.Find(roomId);
        if (room == null) {
            // HANDLE_ERROR -> room non trovato 404 + mex ? c'è single or throw
        }
        
        await _roomRepo.Delete(room);
        await SendOkAsync(cancellation: ct);
    }
}
