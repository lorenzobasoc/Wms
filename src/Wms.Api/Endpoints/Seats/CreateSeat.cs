using Wms.Api.Authorization;
using Wms.Api.Dtos.Seats;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Seats;

public class CreateSeat(SeatRepo seatRepo) : Endpoint<SeatDetailDto>
{
    private readonly SeatRepo _seatRepo = seatRepo;

    public override void Configure() {
        Post(ApiRoutes.Seats.Edit);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(SeatDetailDto req, CancellationToken ct) {
        var seat = req.ToEntity(req.TableId);
        await _seatRepo.Create(seat);
        await SendOkAsync(cancellation: ct);
    }
}
