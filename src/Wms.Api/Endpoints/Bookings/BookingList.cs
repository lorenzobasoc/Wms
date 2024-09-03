using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Bookings;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Bookings;

public class BookingList(BookingRepo bookingRepo) : EndpointWithoutRequest<List<BookingDetailDto>>
{
    private readonly BookingRepo _bookingRepo = bookingRepo;

    public override void Configure() {
        Get(ApiRoutes.Bookings.List);
        Policies(AppPolicies.ADMIN_POLICY);
    }

    public override async Task<List<BookingDetailDto>> HandleAsync(CancellationToken ct) {
        var bookings = await _bookingRepo.List();
        var res = bookings
            .Select(u => u.ToBookingDetail())
            .ToList();
        return res;
    }
}
