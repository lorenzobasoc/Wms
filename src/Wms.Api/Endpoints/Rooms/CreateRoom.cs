using Wms.Api.Authorization;
using Wms.Api.Dtos.Rooms;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Rooms;

public class CreateRoom(RoomRepo roomRepo) : Endpoint<RoomEditDto>
{
    private readonly RoomRepo _roomRepo = roomRepo;

    public override void Configure() {
        Post(ApiRoutes.Rooms.Edit);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(RoomEditDto req, CancellationToken ct) {
        var room = req.ToEntity();
        await _roomRepo.Create(room);
        await SendOkAsync(cancellation: ct);
    }
}
