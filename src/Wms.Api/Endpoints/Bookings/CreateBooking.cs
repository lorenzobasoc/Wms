using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Bookings;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Bookings;

public class CreateBooking: Endpoint<BookingDetailDto>
{
    private readonly BookingRepo _bookingRepo;
    private readonly UserRepo _userRepo;

    public override void Configure() {
        Post(ApiRoutes.Bookings.Edit);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(BookingDetailDto req, CancellationToken ct) {
        
        var userId = await _userRepo.GetUserId(User.Identity.Name);
        var booking = req.ToEntity();
        await _bookingRepo.Create(booking);
        await SendOkAsync(cancellation: ct);
    }
}