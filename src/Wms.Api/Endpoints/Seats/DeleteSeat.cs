using Wms.Api.Constants.Authorization;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Seats;

public class DeleteSeat : EndpointWithoutRequest
{
    public SeatRepo SeatRepo { get; set; }

    public override void Configure() {
        Delete(ApiRoutes.Seats.Delete + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var seatId = Route<Guid>(ApiRoutes.IdParam);
        var seat = await SeatRepo.Find(seatId);
        if (seat == null) {
            // HANDLE_ERROR -> seat non trovato 404 + mex ? c'è single or throw
        }
        await SeatRepo.Delete(seat);
        await SendOkAsync(cancellation: ct);
    }
}
