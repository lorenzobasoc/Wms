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
        var bookingId = Route<Guid>(ApiRoutes.IdParam);
        var userId = await UserRepo.GetUserId(User.Identity.Name);
        var booking = await BookingRepo.Find(bookingId);
        if (booking == null) {
            // HANDLE_ERROR -> booking non trovato 404 + mex occhio che c'è il SingleOrThrow
        }
        if  (booking.HasUser(userId)) {
            // HANDLE_ERROR: throw forbidden o null?
        }
        var dto = booking.ToBookingDetail();
        await SendAsync(dto, cancellation: ct);
    }
}
