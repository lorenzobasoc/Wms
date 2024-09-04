using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Rooms;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Rooms;

public class CreateRoom : Endpoint<RoomEditDto>
{
    public RoomRepo RoomRepo { get; set; }

    public override void Configure() {
        Post(ApiRoutes.Rooms.Edit);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(RoomEditDto req, CancellationToken ct) {
        var room = req.ToEntity();
        await RoomRepo.Create(room);
        await SendOkAsync(cancellation: ct);
    }
}
