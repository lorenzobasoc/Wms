using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Seats;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Seats;

public class SeatEdit : Endpoint<SeatDetailDto>
{
    public SeatRepo SeatRepo { get; set; }

    public override void Configure() {
        Put(ApiRoutes.Seats.Edit + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(SeatDetailDto req, CancellationToken ct) {
        var seatId = Route<Guid>(ApiRoutes.IdParam);
        var seat = await SeatRepo.Find(seatId);
        if (seat == null) {
            // HANDLE_ERROR -> utente non registrato 401 + mex ? 
        }
        UpdateProperties(seat, req);
        await SeatRepo.Update(seat);
        await SendOkAsync(cancellation: ct);
    }

    private static void UpdateProperties(Seat seat, SeatDetailDto req) {
        seat.Name = req.Name ?? seat.Name;
    }
}
