using Wms.Api.Constants.Authorization;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Bookings;

public class DeleteBooking : EndpointWithoutRequest
{
    public BookingRepo BookingRepo { get; set; }
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Delete(ApiRoutes.Bookings.Delete + ApiRoutes.IdParam);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var bookingId = Route<Guid>(ApiRoutes.IdParam);
        var userId = await UserRepo.GetUserId(User.Identity.Name);
        var booking = await BookingRepo.Find(bookingId);
        if (booking == null) {
            // HANDLE_ERROR -> booking non trovato 404 + mex ? c'è single or throw
        }
         if  (booking.HasUser(userId)) {
            // HANDLE_ERROR: throw forbidden o null?
        }
        await BookingRepo.Delete(booking);
        await SendOkAsync(cancellation: ct);
    }
}
