using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Bookings;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Bookings;

public class ActiveBookingList : EndpointWithoutRequest<List<BookingDetailDto>>
{
    public BookingRepo BookingRepo { get; set; }

    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Get(ApiRoutes.Bookings.ListActives);
        Policies(AppPolicies.WORKER_POLICY);
    }

    public override async Task<List<BookingDetailDto>> HandleAsync(CancellationToken ct) {
        var userId = await UserRepo.GetUserId(User.Identity.Name);
        var bookings = await BookingRepo.ListActives(userId);
        var res = bookings
            .Select(u => u.ToBookingDetail())
            .ToList();
        return res;
    }
}
