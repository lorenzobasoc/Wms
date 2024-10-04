using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Bookings;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Bookings;

public class BookingDetail : EndpointWithoutRequest<BookingDetailDto>
{
    public BookingRepo BookingRepo { get; set; }
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Get(ApiRoutes.Bookings.Detail + ApiRoutes.IdParam);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var bookingId = Route<Guid>("Id");
        var userId = await UserRepo.GetUserId(User.Identity.Name);
        var booking = await BookingRepo.Find(bookingId);
        if (booking == null) {
            await SendNotFoundAsync(ct);
        }
        if (!booking.HasUser(userId)) {
            await SendForbiddenAsync(ct);
        }
        var dto = booking.ToBookingDetail();
        await SendAsync(dto, cancellation: ct);
    }
}
