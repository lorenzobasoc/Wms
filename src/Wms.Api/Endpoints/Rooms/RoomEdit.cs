using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Rooms;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Rooms;

public class RoomEdit : Endpoint<RoomEditDto>
{
    public RoomRepo RoomRepo { get; set; }

    public override void Configure() {
        Put(ApiRoutes.Rooms.Edit + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(RoomEditDto req, CancellationToken ct) {
        var roomId = Route<Guid>(ApiRoutes.IdParam);
        var room = await RoomRepo.Find(roomId);
        if (room == null) {
            await SendNotFoundAsync(ct);
        }
        UpdateProperties(room, req);
        await RoomRepo.Update(room);
        await SendOkAsync(cancellation: ct);
    }

    private static void UpdateProperties(Room room, RoomEditDto req) {
        room.Name = req.Name ?? room.Name;
        room.Description = req.Description ?? room.Description;
        room.Photo.Data = req.Photo ?? room.Photo.Data;
    }
}
