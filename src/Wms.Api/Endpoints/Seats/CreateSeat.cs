using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Seats;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Seats;

public class CreateSeat : Endpoint<SeatDetailDto>
{
    public SeatRepo SeatRepo { get; set; }

    public override void Configure() {
        Post(ApiRoutes.Seats.Edit);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(SeatDetailDto req, CancellationToken ct) {
        var seat = req.ToEntity(req.TableId);
        await SeatRepo.Create(seat);
        await SendOkAsync(cancellation: ct);
    }
}
