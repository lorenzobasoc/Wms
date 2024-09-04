using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Rooms;

public class RoomList : EndpointWithoutRequest<ListItemDto[]>
{
    public RoomRepo RoomRepo { get; set; }

    public override void Configure() {
        Get(ApiRoutes.Rooms.List + ApiRoutes.FloorIdParam);
        Policies(AppPolicies.WORKER_POLICY);
    }

    public override async Task<ListItemDto[]> HandleAsync(CancellationToken ct) {
        var floorId = Route<Guid>(ApiRoutes.FloorIdParam);
        var rooms = await RoomRepo.List(floorId);
        var res = rooms
            .Select(u => new ListItemDto {
                Id = u.Id,
                Description = u.Name
            })
            .ToArray();
        return res;
    }
}
