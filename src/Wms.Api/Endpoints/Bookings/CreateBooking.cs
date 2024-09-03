using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Bookings;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Bookings;

public class CreateBooking : Endpoint<BookingEditDto>
{
    public BookingRepo BookingRepo { get; set; }
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Post(ApiRoutes.Bookings.Edit);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(BookingEditDto req, CancellationToken ct) {
        var userId = await UserRepo.GetUserId(User.Identity.Name);
        var booking = req.ToEntity();
        booking.Users.Add(new UserBooking {
            UserId = userId,
            BookingId = booking.Id,
        });
        await BookingRepo.Create(booking);
        await SendOkAsync(cancellation: ct);
    }
}