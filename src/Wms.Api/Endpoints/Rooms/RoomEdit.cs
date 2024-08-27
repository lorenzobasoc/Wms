using Wms.Api.Authorization;
using Wms.Api.Dtos.Rooms;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Rooms;

public class RoomEdit(RoomRepo roomRepo) : Endpoint<RoomEditDto>
{
    private readonly RoomRepo _roomRepo = roomRepo;

    public override void Configure() {
        Put(ApiRoutes.Rooms.Edit + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(RoomEditDto req, CancellationToken ct) {
        var roomId = Route<Guid>(ApiRoutes.IdParam);
        var room = await _roomRepo.Find(roomId);
        if (room == null) {
            // HANDLE_ERROR -> utente non registrato 401 + mex ? 
        }
        UpdateProperties(room, req);
        await _roomRepo.Update(room);
        await SendOkAsync(cancellation: ct);
    }

    private static void UpdateProperties(Room room, RoomEditDto req) {
        room.Name = req.Name ?? room.Name;
        room.Description = req.Description ?? room.Description;
        room.Photo.Data = req.Photo ?? room.Photo.Data;
    }
}
