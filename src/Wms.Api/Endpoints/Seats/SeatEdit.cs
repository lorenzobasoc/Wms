using Wms.Api.Authorization;
using Wms.Api.Dtos.Seats;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Seats;

public class SeatEdit(SeatRepo seatRepo) : Endpoint<SeatDetailDto>
{
    private readonly SeatRepo _seatRepo = seatRepo;

    public override void Configure() {
        Put(ApiRoutes.Seats.Edit + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(SeatDetailDto req, CancellationToken ct) {
        var seatId = Route<Guid>(ApiRoutes.IdParam);
        var seat = await _seatRepo.Find(seatId);
        if (seat == null) {
            // HANDLE_ERROR -> utente non registrato 401 + mex ? 
        }
        UpdateProperties(seat, req);
        await _seatRepo.Update(seat);
        await SendOkAsync(cancellation: ct);
    }

    private static void UpdateProperties(Seat seat, SeatDetailDto req) {
        seat.Name = req.Name ?? seat.Name;
    }
}
