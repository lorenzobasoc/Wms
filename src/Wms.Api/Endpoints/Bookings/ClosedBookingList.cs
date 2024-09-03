using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Bookings;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Bookings;

public class ClosedBookingList(BookingRepo bookingRepo, UserRepo userRepo) : EndpointWithoutRequest<List<BookingDetailDto>>
{
    private readonly BookingRepo _bookingRepo = bookingRepo;
    private readonly UserRepo _userRepo = userRepo;

    public override void Configure() {
        Get(ApiRoutes.Bookings.ListClosed);
        Policies(AppPolicies.WORKER_POLICY);
    }

    public override async Task<List<BookingDetailDto>> HandleAsync(CancellationToken ct) {
        var userId = await _userRepo.GetUserId(User.Identity.Name);
        var bookings = await _bookingRepo.ListClosed(userId);
        var res = bookings
            .Select(u =>u.ToBookingDetail())
            .ToList();
        return res;
    }
}
