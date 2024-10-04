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
        var bookingId = Route<Guid>("Id");
        var user = await UserRepo.Find(User.Identity.Name);
        var booking = await BookingRepo.Find(bookingId);
        if (booking == null) {
            await SendNotFoundAsync(ct);
        }
        if (!booking.HasUser(user.Id)) {
            await SendForbiddenAsync(ct);
        }
        await BookingRepo.Delete(booking);
        await SendOkAsync(cancellation: ct);
    }
}
